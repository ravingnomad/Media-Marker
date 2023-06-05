DELIMITER //

CREATE DEFINER=`root`@`localhost` PROCEDURE `search_book`(
bookStatus INT,
searchField TEXT,
searchQuery TEXT
)
BEGIN
	IF searchField = 'Title' THEN
		SELECT all_books.title, all_books.author, all_books.genres
        FROM all_books
        WHERE all_books.title LIKE CONCAT('%', searchQuery,'%') AND all_books.status = bookStatus AND searchQuery != '';
        
	ELSEIF searchField = 'Author' THEN
		SELECT all_books.title, all_books.author, all_books.genres
        FROM all_books 
        WHERE all_books.author LIKE CONCAT('%', searchQuery,'%') AND all_books.status = bookStatus AND searchQuery != '';
        
	ELSEIF searchField = 'Genre' THEN
		SET @genreQueryLength = LENGTH(searchQuery);
        CREATE TABLE tempMatchedGenre(title TEXT, author TEXT, genres TEXT);
			parseLoop: LOOP
				#strip leading and trailing white spaces
				SET @genreName = LOWER(TRIM(SUBSTRING_INDEX(searchQuery, ',', 1)));
                SET @genreNameLength = LENGTH(@genreName);
                
				INSERT INTO tempMatchedGenre 
                SELECT all_books.title, all_books.author, all_books.genres
                FROM all_books
                WHERE all_books.genres LIKE CONCAT('%', @genreName, '%') AND all_books.status = bookStatus AND @genreName != '';
                
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