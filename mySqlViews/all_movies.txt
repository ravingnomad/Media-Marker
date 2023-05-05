CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_movies` AS
    SELECT 
        `movies`.`movie_id` AS `movie_id`,
        `movies`.`title` AS `title`,
        `movies`.`director` AS `director`,
        `allgenrenames`.`genres` AS `genres`,
        `media_pieces`.`status` AS `status`
    FROM
        ((`movies`
        JOIN `all_media_piece_genre_names` `allgenrenames` ON (((`allgenrenames`.`media_type_id` = 3)
            AND (`allgenrenames`.`media_id` = `movies`.`movie_id`))))
        JOIN `media_pieces` ON (((`media_pieces`.`media_type_id` = 3)
            AND (`media_pieces`.`media_id` = `movies`.`movie_id`))))
    GROUP BY `movies`.`movie_id`