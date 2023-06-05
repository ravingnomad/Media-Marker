DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_movie`(
mediaTypeID INT,
movieTitle TEXT, 
director TEXT,
movieGenresString TEXT,
mediaStatus INT)
BEGIN
	START TRANSACTION;
    
		INSERT INTO movies(title, director)
		VALUES(movieTitle, director);
        SET @newMovieID = (SELECT LAST_INSERT_ID());
        
		CALL insert_genre(mediaTypeID, @newMovieID, movieGenresString);

		CALL insert_media_piece(mediaTypeID, @newMovieID, mediaStatus);
        
    COMMIT;
END//

DELIMITER ;