DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `insert_game`(
mediaTypeID INT, 
gameTitle TEXT, 
developer TEXT, 
gameGenresString TEXT, 
supportedPlatformsString TEXT,
mediaStatus INT)
BEGIN
	START TRANSACTION;
		
        #insert game title and developer name into video_games table and get the game's id
		INSERT INTO video_games(title, developer)
		VALUES(gameTitle, developer);
        SET @newGameID = (SELECT LAST_INSERT_ID());
        
        #insert game genres into the media_genre table
        CALL insert_genre(mediaTypeID, @newGameID, gameGenresString);
        
        #insert the game's supported platforms into the supported_game_platforms table
        CALL insert_supported_game_platform(@newGameID, supportedPlatformsString);
        
        #create a new media piece for the game and insert that into the media_pieces table along with whether it is 'Possessed' or 'Desired'
		CALL insert_media_piece(mediaTypeID, @newGameID, mediaStatus);
        
	COMMIT;
END//

DELIMITER ;