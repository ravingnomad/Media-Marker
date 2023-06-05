CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_media_piece_genre_names` AS
    SELECT 
        `media_genre`.`media_type_id` AS `media_type_id`,
        `media_genre`.`media_id` AS `media_id`,
        GROUP_CONCAT(`genre_types`.`genre_name`
            SEPARATOR ',') AS `genres`
    FROM
        (`media_genre`
        JOIN `genre_types` ON ((`genre_types`.`genre_id` = `media_genre`.`genre_id`)))
    GROUP BY `media_genre`.`media_type_id` , `media_genre`.`media_id`