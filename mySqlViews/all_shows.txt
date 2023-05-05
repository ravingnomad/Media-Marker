CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_shows` AS
    SELECT 
        `tv_shows`.`tv_show_id` AS `tv_show_id`,
        `tv_shows`.`title` AS `title`,
        `tv_shows`.`director` AS `director`,
        `allgenrenames`.`genres` AS `genres`,
        `media_pieces`.`status` AS `status`
    FROM
        ((`tv_shows`
        JOIN `all_media_piece_genre_names` `allgenrenames` ON (((`allgenrenames`.`media_type_id` = 4)
            AND (`allgenrenames`.`media_id` = `tv_shows`.`tv_show_id`))))
        JOIN `media_pieces` ON (((`media_pieces`.`media_type_id` = 4)
            AND (`media_pieces`.`media_id` = `tv_shows`.`tv_show_id`))))
    GROUP BY `tv_shows`.`tv_show_id`