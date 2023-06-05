DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `change_media_status`(
mediaTypeID INT,
mediaID INT,
newStatus TEXT
)
BEGIN
	UPDATE media_pieces
    SET status = newStatus
    WHERE media_type_id = mediaTypeID AND media_id = mediaID;
END//

DELIMITER ;