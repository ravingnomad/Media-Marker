DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `list_all_books`(
mediaStatusEnum INT)
BEGIN
START TRANSACTION;
    #select * works because dapper will only put data into those variables whose names correctly match the column names; so even though this 
    #statement also selects all columns in 'media_pieces', user will never see that data because we do not have variables in our 'Book'
    #class that matches the column names of 'media_pieces'
	SELECT *
    FROM all_books
    WHERE all_books.status = mediaStatusEnum;
COMMIT;
END//

DELIMITER ;