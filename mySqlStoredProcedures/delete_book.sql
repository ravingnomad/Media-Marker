DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_book`(
bookEnum INT,
bookID INT
)
BEGIN
START TRANSACTION;
	DELETE books, media_pieces, media_genre
    FROM books
    JOIN media_pieces
    ON books.book_id = media_pieces.media_id AND media_pieces.media_type_id = bookEnum
    JOIN media_genre
    ON media_pieces.media_id = media_genre.media_id AND media_genre.media_type_id = bookEnum
    WHERE books.book_id = bookID;
COMMIT;
END//

DELIMITER ;