DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `delete_game`(
gameEnum INT,
gameID INT
)
BEGIN
START TRANSACTION;
	DELETE video_games, media_pieces, media_genre, supported_game_platforms
    FROM video_games
    JOIN media_pieces
    ON video_games.video_game_id = media_pieces.media_id AND media_pieces.media_type_id = gameEnum
    JOIN media_genre
    ON media_pieces.media_id = media_genre.media_id AND media_genre.media_type_id = gameEnum
    JOIN supported_game_platforms
    ON video_games.video_game_id = supported_game_platforms.game_id
    WHERE video_games.video_game_id = gameID;
COMMIT;
END//

DELIMITER ;