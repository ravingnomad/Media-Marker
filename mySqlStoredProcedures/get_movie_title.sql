DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_movie_title`(
title TEXT)
BEGIN
	SELECT *
    FROM all_movies
    WHERE all_movies.title = title;
END//

DELIMITER ;