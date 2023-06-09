DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_show`(
showEnum INT,
showID INT
)
BEGIN
START TRANSACTION;
	DELETE tv_shows, media_pieces, media_genre
    FROM tv_shows
    JOIN media_pieces
    ON tv_shows.tv_show_id = media_pieces.media_id AND media_pieces.media_type_id = showEnum
    JOIN media_genre
    ON media_pieces.media_id = media_genre.media_id AND media_genre.media_type_id = showEnum
    WHERE tv_shows.tv_show_id = showID;
COMMIT;
END//

DELIMITER ;