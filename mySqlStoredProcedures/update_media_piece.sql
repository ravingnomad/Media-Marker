DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `update_media_piece`(
mediaTypeEnum INT,
mediaID INT,
fieldToChange TEXT,
stringValue TEXT,
intValue INT
)
BEGIN
	START TRANSACTION;
		SET @mediaType = (SELECT media_type FROM media_types_lookup WHERE mediaTypeEnum = media_type_key);
        
		IF @mediaType = "Book" THEN
			IF LOWER(fieldToChange) = 'title' THEN
				UPDATE books
				SET books.title = stringValue
				WHERE books.book_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'author' THEN
				UPDATE books
				SET books.author = stringValue
				WHERE books.book_id = mediaID;
			END IF;
            
            
		ELSEIF @mediaType = "Movie" THEN
			IF LOWER(fieldToChange) = 'title' THEN
				UPDATE movies
				SET movies.title = stringValue
				WHERE movies.movie_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'director' THEN
				UPDATE movies
				SET movies.director = stringValue
				WHERE movies.movie_id = mediaID;
			END IF;
            
            
		ELSEIF @mediaType = "TV Show" THEN
			IF LOWER(fieldToChange) = 'title' THEN
				UPDATE tv_shows
				SET tv_shows.title = stringValue
				WHERE tv_shows.tv_show_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'director' THEN
				UPDATE tv_shows
				SET tv_shows.director = stringValue
				WHERE tv_shows.tv_show_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'seasons' THEN
				UPDATE tv_shows
				SET tv_shows.seasons = intValue
				WHERE tv_shows.tv_show_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'episodes' THEN
				UPDATE tv_shows
				SET tv_shows.episodes = intValue
				WHERE tv_shows.tv_show_id = mediaID;
			END IF;
        
        
		ELSEIF @mediaType = "Video Game" THEN
			IF LOWER(fieldToChange) = 'title' THEN
				UPDATE video_games
				SET video_games.title = stringValue
				WHERE video_games.video_game_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'developer' THEN
				UPDATE video_games
				SET video_games.developer = stringValue
				WHERE video_games.video_game_id = mediaID;
			ELSEIF LOWER(fieldToChange) = 'platforms' THEN
				DELETE
				FROM supported_game_platforms
				WHERE supported_game_platforms.game_id = mediaID;
				SET @stringLen = LENGTH(stringValue);
				insertionLoop: LOOP
					SET @platformName = SUBSTRING_INDEX(stringValue, ',', 1);
					SET @platformID = (SELECT platform_id FROM game_platforms WHERE platform_name = @platformName);
					SET @substringLen = LENGTH(@platformName);
					INSERT INTO supported_game_platforms(game_id, platform_id)
					VALUES(mediaID, @platformID);
					#the +2 is to skip the last letter of the substring along with the comma
					SET stringValue = MID(stringValue, @substringLen + 2, @stringLen);
					IF stringValue IS NULL OR stringValue = '' THEN
						LEAVE insertionLoop;
					END IF;
				END LOOP insertionLoop;
			END IF;
		END IF;
    COMMIT;
END//

DELIMITER ;