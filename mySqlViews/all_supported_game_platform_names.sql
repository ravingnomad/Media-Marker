CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_supported_game_platform_names` AS
    SELECT 
        `video_games`.`video_game_id` AS `video_game_id`,
        GROUP_CONCAT(`namedgameplatforms`.`platform_name`
            SEPARATOR ',') AS `platforms`
    FROM
        (`video_games`
        JOIN (SELECT 
            `supported_game_platforms`.`game_id` AS `game_id`,
                `game_platforms`.`platform_name` AS `platform_name`
        FROM
            (`supported_game_platforms`
        JOIN `game_platforms`)
        WHERE
            (`supported_game_platforms`.`platform_id` = `game_platforms`.`platform_id`)) `namedgameplatforms` ON ((`namedgameplatforms`.`game_id` = `video_games`.`video_game_id`)))
    GROUP BY `video_games`.`video_game_id`