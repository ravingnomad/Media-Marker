DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_book_title`(
title TEXT
)
BEGIN
	SELECT *
    FROM all_books
    WHERE all_books.title = title;
END//

DELIMITER ;