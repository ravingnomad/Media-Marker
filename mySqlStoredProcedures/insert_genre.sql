DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_genre`(mediaType INT, mediaID INT, genreString VARCHAR(6555))
BEGIN
    
	SET @stringLen = LENGTH(genreString);
	insertionLoop: LOOP
		
        SET @genreName = SUBSTRING_INDEX(genreString, ',', 1);
        SET @genreID = (SELECT genre_id FROM genre_types WHERE genre_name = @genreName);
        SET @substringLen = LENGTH(@genreName);
        
        INSERT INTO media_genre(genre_id, media_type_id, media_id)
        VALUES(@genreID, mediaType, mediaID);
        
        SET genreString = MID(genreString, @substringLen + 2, @stringLen);

        IF genreString IS NULL OR genreString = '' THEN
			LEAVE insertionLoop;
		END IF;
    END LOOP insertionLoop;
END//

DELIMITER ;