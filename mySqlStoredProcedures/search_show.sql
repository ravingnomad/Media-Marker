DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `search_show`(
showStatus INT,
searchField TEXT,
searchQuery TEXT
)
BEGIN
	IF searchField = 'Title' THEN
		SELECT all_shows.title, all_shows.director, all_shows.genres
        FROM all_shows 
        WHERE all_shows.title LIKE CONCAT('%', searchQuery,'%') AND searchQuery != '';
        
	ELSEIF searchField = 'Director' THEN
		SELECT all_shows.title, all_shows.director, all_shows.genres 
        FROM all_shows 
        WHERE all_shows.director LIKE CONCAT('%', searchQuery,'%') AND searchQuery != '';
        
	ELSEIF searchField = 'Genre' THEN
		SET @genreQueryLength = LENGTH(searchQuery);
        CREATE TABLE tempMatchedGenre(title TEXT, director TEXT, genres TEXT);
			parseLoop: LOOP
				#strip leading and trailing white spaces
				SET @genreName = LOWER(TRIM(SUBSTRING_INDEX(searchQuery, ',', 1)));
                SET @genreNameLength = LENGTH(@genreName);
                
				INSERT INTO tempMatchedGenre 
                SELECT all_shows.title, all_shows.director, all_shows.genres
                FROM all_shows
                WHERE all_shows.genres LIKE CONCAT('%', @genreName, '%') AND @genreName != '';
                
                SET searchQuery = MID(searchQuery, @genreNameLength + 2, @genreQueryLength);
                IF searchQuery IS NULL OR searchQuery = '' THEN
					LEAVE parseLoop;
				END IF;
			END LOOP;
            SELECT DISTINCT * FROM tempMatchedGenre;
            DROP TABLE tempMatchedGenre;
	END IF;
END//

DELIMITER ;