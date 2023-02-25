using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Media_Types;

namespace MySql_Helper
{
    public static class mysqlHelper
    {
        /*static variables are maintained; always check if connString is null before each database connection;
         for each interaction with the database, connect and close connection when interaction done; don't want to
        leave it open!*/
        private static string connString;
        private enum MediaTypeNames
        {
            Book = 1,
            Video_Game = 2,
            Movie = 3,
            TV_Show = 4
        }

        private static void loadConnString()
        {
            string rootDir = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            using (StreamReader reader = new StreamReader(rootDir + "\\connectionString.txt"))
            {
                connString = reader.ReadLine();
            }
        }


        public static void addNewBook(string bookTitle, string bookAuthor, List<string> bookGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new book into the 'Books' table
                var bookValues = new { bookTitle = bookTitle, bookAuthor = bookAuthor };
                int newBookID = connection.Query<int>("insert_book", bookValues, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];

                //Add the list of book genres into 'media_genre' table
                foreach (string genre in bookGenres)
                {
                    var genreValue = new { mediaType = MediaTypeNames.Book, mediaID = newBookID, genre = genre };
                    connection.Query("insert_genre", genreValue, commandType: System.Data.CommandType.StoredProcedure);
                }

                //Create a new media piece, and add it to the "media piece" table with appropriate 'possessed' or 'desired' flag
                var mediaPieceValue = new { mediaType = MediaTypeNames.Book, mediaID = newBookID, mediaStatus = originTab };
                connection.Query("insert_media_piece", mediaPieceValue, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void addNewMovie(string movieTitle, string movieDirector, List<string> movieGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new movie into the 'Movies' table
                var movieValues = new { movieTitle = movieTitle, movieDirector = movieDirector };
                int newMovieID = connection.Query<int>("insert_movie", movieValues, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                
                //Add the list of movie genres into 'media_genre' table
                foreach (string genre in movieGenres)
                {
                    var genreValue = new { mediaType = MediaTypeNames.Movie, mediaID = newMovieID, genre = genre };
                    connection.Query("insert_genre", genreValue, commandType: System.Data.CommandType.StoredProcedure);
                }

                //Create a new media piece, and add it to the "media piece" table with appropriate 'possessed' or 'desired' flag
                var mediaPieceValue = new { mediaType = MediaTypeNames.Movie, mediaID = newMovieID, mediaStatus = originTab };
                connection.Query("insert_media_piece", mediaPieceValue, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void addNewShow(string showTitle, string showDirector, int seasons, int episodes, List<string> showGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new show into the 'show' table
                var showValues = new { showTitle = showTitle, showDirector = showDirector, showSeasons = seasons, showEpisodes = episodes };
                int newShowID = connection.Query<int>("insert_show", showValues, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                
                //Add the list of show genres into 'media_genre' table
                foreach (string genre in showGenres)
                {
                    var genreValue = new { mediaType = MediaTypeNames.TV_Show, mediaID = newShowID, genre = genre };
                    connection.Query("insert_genre", genreValue, commandType: System.Data.CommandType.StoredProcedure);
                }
                
                //Create a new media piece, and add it to the "media piece" table with appropriate 'possessed' or 'desired' flag
                var mediaPieceValue = new { mediaType = MediaTypeNames.TV_Show, mediaID = newShowID, mediaStatus = originTab };
                connection.Query("insert_media_piece", mediaPieceValue, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void addNewGame(string newGameTitle, string newGameDeveloper, List<string> gameGenres, List<string> gamePlatforms, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new game into the 'video game' table
                var gameValues = new { gameTitle = newGameTitle, developer = newGameDeveloper };
                int newGameID = connection.Query<int>("insert_game", gameValues, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                
                //Add the list of video game genres into 'media_genre' table
                foreach (string genre in gameGenres)
                {
                    var genreValue = new { mediaType = MediaTypeNames.Video_Game, mediaID = newGameID, genre = genre };
                    connection.Query("insert_genre", genreValue, commandType: System.Data.CommandType.StoredProcedure);
                }

                //Add the list of game platforms into 'supported_game_platforms' table
                foreach (string platform in gamePlatforms)
                {
                    var platformValue = new { newGameId = newGameID, supportedPlatform = platform };
                    connection.Query("insert_supported_game_platform", platformValue, commandType: System.Data.CommandType.StoredProcedure);
                }

                //Create a new media piece, and add it to the "media piece" table with appropriate 'possessed' or 'desired' flag
                var mediaPieceValue = new { mediaType = MediaTypeNames.Video_Game, mediaID = newGameID, mediaStatus = originTab };
                connection.Query("insert_media_piece", mediaPieceValue, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
