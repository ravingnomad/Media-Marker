DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_book`(
bookID INT)
BEGIN
	SELECT books.book_id, books.title, books.author, GROUP_CONCAT(genre_name) AS 'genres'
    FROM books
    JOIN media_genre
    ON books.book_id = bookID AND media_genre.media_id = bookID AND media_genre.media_type_id = 1
    JOIN genre_types
    ON media_genre.genre_id = genre_types.genre_id;
END//

DELIMITER ;