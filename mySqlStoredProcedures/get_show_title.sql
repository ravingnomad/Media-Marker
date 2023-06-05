DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_show_title`(
title TEXT)
BEGIN
	SELECT *
    FROM all_shows
    WHERE all_shows.title = title;
END//

DELIMITER ;