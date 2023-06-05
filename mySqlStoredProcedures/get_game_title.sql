DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_game_title`(
title TEXT)
BEGIN
	SELECT *
    FROM all_games
    WHERE all_games.title = title;
END//

DELIMITER ;