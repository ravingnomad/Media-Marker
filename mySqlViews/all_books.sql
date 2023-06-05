CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `root`@`localhost` 
    SQL SECURITY DEFINER
VIEW `all_books` AS
    SELECT 
        `books`.`book_id` AS `book_id`,
        `books`.`title` AS `title`,
        `books`.`author` AS `author`,
        `allgenrenames`.`genres` AS `genres`,
        `media_pieces`.`status` AS `status`
    FROM
        ((`books`
        JOIN `all_media_piece_genre_names` `allgenrenames` ON (((`allgenrenames`.`media_type_id` = 1)
            AND (`allgenrenames`.`media_id` = `books`.`book_id`))))
        JOIN `media_pieces` ON (((`media_pieces`.`media_type_id` = 1)
            AND (`media_pieces`.`media_id` = `books`.`book_id`))))
    GROUP BY `books`.`book_id`