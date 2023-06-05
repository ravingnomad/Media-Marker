DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_show`(
mediaTypeID INT,
showTitle TEXT, 
director TEXT, 
seasons INT, 
episodes INT,
showGenresString TEXT,
mediaStatus INT)
BEGIN
	START TRANSACTION;
		INSERT INTO tv_shows(title, director, seasons, episodes)
		VALUES(showTitle, director, seasons, episodes);
        SET @newShowID = (SELECT LAST_INSERT_ID());
        
		CALL insert_genre(mediaTypeID, @newShowID, showGenresString);

		CALL insert_media_piece(mediaTypeID, @newShowID, mediaStatus);
    COMMIT;
END//

DELIMITER ;