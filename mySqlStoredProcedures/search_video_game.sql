DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `search_video_game`(
gameStatus INT,
searchField TEXT,
searchQuery TEXT
)
BEGIN
	IF searchField = 'Title' THEN
		SELECT all_games.title, all_games.developer, all_games.genres, all_games.platforms
        FROM all_games 
        WHERE all_games.title LIKE CONCAT('%', searchQuery,'%') AND all_games.status = gameStatus AND searchQuery != '';
        
	ELSEIF searchField = 'Developer' THEN
		SELECT all_games.title, all_games.developer, all_games.genres, all_games.platforms 
        FROM all_games 
        WHERE all_games.developer LIKE CONCAT('%', searchQuery,'%') AND all_games.status = gameStatus AND searchQuery != '';
        
	ELSEIF searchField = 'Genre' THEN
		SET @genreQueryLength = LENGTH(searchQuery);
        CREATE TABLE tempMatchedGenre(title TEXT, developer TEXT, genres TEXT, platforms TEXT);
			parseLoop: LOOP
				#strip leading and trailing white spaces
				SET @genreName = LOWER(TRIM(SUBSTRING_INDEX(searchQuery, ',', 1)));
                SET @genreNameLength = LENGTH(@genreName);
                
				INSERT INTO tempMatchedGenre 
                SELECT all_games.title, all_games.developer, all_games.genres, all_games.platforms
                FROM all_games
                WHERE all_games.genres LIKE CONCAT('%', @genreName, '%') AND all_games.status = gameStatus AND @genreName != '';
                
                SET searchQuery = MID(searchQuery, @genreNameLength + 2, @genreQueryLength);
                IF searchQuery IS NULL OR searchQuery = '' THEN
					LEAVE parseLoop;
				END IF;
			END LOOP;
            SELECT DISTINCT * FROM tempMatchedGenre;
            DROP TABLE tempMatchedGenre;
            
	ELSEIF searchField = 'Platform' THEN
		SET @platformQueryLength = LENGTH(searchQuery);
        CREATE TABLE tempMatchedPlatform(title TEXT, developer TEXT, genres TEXT, platforms TEXT);
			parseLoop: LOOP
				#strip leading and trailing white spaces
				SET @platformName = LOWER(TRIM(SUBSTRING_INDEX(searchQuery, ',', 1)));
                SET @platformNameLength = LENGTH(@platformName);
                
				INSERT INTO tempMatchedPlatform 
                SELECT all_games.title, all_games.developer, all_games.genres, all_games.platforms
                FROM all_games
                WHERE all_games.platforms LIKE CONCAT('%', @genreName, '%') AND all_games.status = gameStatus AND @genreName != '';
                
                SET searchQuery = MID(searchQuery, @platformNameLength + 2, @platformQueryLength);
                IF searchQuery IS NULL OR searchQuery = '' THEN
					LEAVE parseLoop;
				END IF;
			END LOOP;
            SELECT DISTINCT * FROM tempMatchedPlatform;
            DROP TABLE tempMatchedPlatform;
	END IF;
END//

DELIMITER ;