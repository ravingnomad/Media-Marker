DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_media_piece`(
mediaType INT, 
mediaID INT, 
mediaStatus INT)
BEGIN
	INSERT INTO media_pieces(media_type_id, media_id, status)
    VALUES(mediaType, mediaID, mediaStatus);

END//

DELIMITER ;