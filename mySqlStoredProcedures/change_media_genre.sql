DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `change_media_genre`(
mediaTypeEnum INT,
mediaPieceID INT,
genres TEXT
)
BEGIN
START TRANSACTION;

	#first delete all genres of specified piece from media_genre; easier to delete all and then insert every marked 'genre' than trying to
    #see if genre already exists in table, as well as deleting those from table that are not mentioned in new 'genres' string
    DELETE
    FROM media_genre
    WHERE media_genre.media_type_id = mediaTypeEnum AND media_genre.media_id = mediaPieceID;
    
    #loop through the genre(s) string
	SET @stringLen = LENGTH(genres);
	insertionLoop: LOOP
        SET @genreName = LOWER(SUBSTRING_INDEX(genres, ',', 1));
        SET @genreID = (SELECT genre_id FROM genre_types WHERE genre_name = @genreName);
        SET @substringLen = LENGTH(@genreName);
        
        INSERT INTO media_genre(genre_ids, media_type_id, media_id)
        VALUES(@genreID, mediaTypeEnum, mediaPieceID);
        
        #the +2 is to skip the last letter of the substring along with the comma
        SET genres = MID(genres, @substringLen + 2, @stringLen);

        IF genres IS NULL OR genres = '' THEN
			LEAVE insertionLoop;
		END IF;
    END LOOP insertionLoop;
    
COMMIT;
END//

DELIMITER ;