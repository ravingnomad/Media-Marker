CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_games` AS
    SELECT 
        `video_games`.`video_game_id` AS `video_game_id`,
        `video_games`.`title` AS `title`,
        `video_games`.`developer` AS `developer`,
        `allgenrenames`.`genres` AS `genres`,
        `allplatformnames`.`platforms` AS `platforms`,
        `media_pieces`.`status` AS `status`
    FROM
        (((`video_games`
        JOIN `all_media_piece_genre_names` `allgenrenames` ON (((`allgenrenames`.`media_type_id` = 2)
            AND (`allgenrenames`.`media_id` = `video_games`.`video_game_id`))))
        JOIN `all_supported_game_platform_names` `allplatformnames` ON ((`allplatformnames`.`video_game_id` = `video_games`.`video_game_id`)))
        JOIN `media_pieces` ON (((`media_pieces`.`media_type_id` = 2)
            AND (`media_pieces`.`media_id` = `video_games`.`video_game_id`))))
    GROUP BY `video_games`.`video_game_id`