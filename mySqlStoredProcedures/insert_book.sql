DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_book`(
mediaTypeID INT,
bookTitle TEXT, 
author TEXT,
bookGenresString TEXT,
mediaStatus INT)
BEGIN
	START TRANSACTION;
    
		INSERT INTO books(title, author)
		VALUES(bookTitle, author);
        SET @newBookID = (SELECT LAST_INSERT_ID());
        
		CALL insert_genre(mediaTypeID, @newBookID, bookGenresString);

		CALL insert_media_piece(mediaTypeID, @newBookID, mediaStatus);
        
    COMMIT;
END//

DELIMITER ;