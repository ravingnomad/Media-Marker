DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_supported_game_platform`(newGameID INT, supportedPlatforms VARCHAR(6555))
BEGIN
	SET @stringLen = LENGTH(supportedPlatforms);
	insertionLoop: LOOP
		
        SET @platformName = SUBSTRING_INDEX(supportedPlatforms, ',', 1);
        SET @platformID = (SELECT platform_id FROM game_platforms WHERE platform_name = @platformName);
        SET @substringLen = LENGTH(@platformName);
        
        INSERT INTO supported_game_platforms(game_id, platform_id)
        VALUES(newGameID, @platformID);
        
        SET supportedPlatforms = MID(supportedPlatforms, @substringLen + 2, @stringLen);

        IF supportedPlatforms IS NULL OR supportedPlatforms = '' THEN
			LEAVE insertionLoop;
		END IF;
    END LOOP insertionLoop;
END//

DELIMITER ;