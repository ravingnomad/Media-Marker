DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_movie`(
movieEnum INT,
movieID INT
)
BEGIN
START TRANSACTION;
	DELETE movies, media_pieces, media_genre
    FROM movies
    JOIN media_pieces
    ON movies.movie_id = media_pieces.media_id AND media_pieces.media_type_id = movieEnum
    JOIN media_genre
    ON media_pieces.media_id = media_genre.media_id AND media_genre.media_type_id = movieEnum
    WHERE movies.movie_id = movieID;
COMMIT;
END//

DELIMITER ;