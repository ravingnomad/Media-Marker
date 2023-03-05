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


        public static void addNewBook(string bookTitle, string author, List<string> bookGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new book and its genre info to the database
                string bookGenresString = String.Join(",", bookGenres);
                var bookValues = new
                {
                    mediaTypeID = MediaTypeNames.Book,
                    bookTitle = bookTitle,
                    author = author,
                    bookGenresString = bookGenresString,
                    mediaStatus = originTab
                };
                connection.Query("insert_book", bookValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void addNewMovie(string movieTitle, string director, List<string> movieGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new movie and its genre info to the database
                string movieGenresString = String.Join(",", movieGenres);
                var movieValues = new {mediaTypeID = MediaTypeNames.Movie,
                                       movieTitle = movieTitle,
                                       director = director,
                                       movieGenresString = movieGenresString,
                                       mediaStatus = originTab
                };
                connection.Query("insert_movie", movieValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void addNewShow(string newShowTitle, string showDirector, int seasons, int episodes, List<string> showGenres, string originTab)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new show and its genre info to the database
                string showGenresString = String.Join(",", showGenres);
                var showValues = new {mediaTypeID = MediaTypeNames.TV_Show,
                                      showTitle = newShowTitle,
                                      director = showDirector,
                                      seasons = seasons,
                                      episodes = episodes,
                                      showGenresString = showGenresString,
                                      mediaStatus = originTab
                };
                connection.Query("insert_show", showValues, commandType: System.Data.CommandType.StoredProcedure);
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
                //Add a new game and its genre and platform info to the database
                string gameGenresString = String.Join(",", gameGenres);
                string gamePlatformsString = String.Join(",", gamePlatforms);
                var gameValues = new { mediaTypeID = MediaTypeNames.Video_Game,
                                       gameTitle = newGameTitle,
                                       developer = newGameDeveloper,
                                       gameGenresString = gameGenresString,
                                       supportedPlatformsString = gamePlatformsString,
                                       mediaStatus = originTab};

                connection.Query("insert_game", gameValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void searchMedia(string mediaStatus, string mediaType, string selectedField, string searchQuery)
        {

        }
    }
}
