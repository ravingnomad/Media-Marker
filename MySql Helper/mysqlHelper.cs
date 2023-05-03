using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Media_Types;
using Enums;

namespace MySql_Helper
{
    public static class mysqlHelper
    {
        private static string connString;

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


        public static List<Book> searchMedia(string mediaStatus, string mediaType, string selectedField, string searchQuery)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new {
                    bookStatus = mediaStatus,
                    searchField = selectedField,
                    searchQuery = searchQuery
                };
                List<Book> result = connection.Query<Book>("search_book", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static Book getBook(int bookID)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var value = new {bookID = bookID};
                Book result = connection.Query<Book>("get_book", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                return result;
            }
        }

        public static List<Book> listAllBooks(string identifierStr)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { identifierString = identifierStr };

                List<Book> result = connection.Query<Book>("list_all_books", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Game> listAllGames(string identifierStr)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { identifierString = identifierStr };

                List<Game> result = connection.Query<Game>("list_all_games", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Movie> listAllMovies(string identifierStr)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { identifierString = identifierStr };

                List<Movie> result = connection.Query<Movie>("list_all_movies", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Show> listAllShows(string identifierStr)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { identifierString = identifierStr };
                Console.WriteLine("Clicked in possessed show");
                List<Show> result = connection.Query<Show>("list_all_shows", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public static void deleteBooks(List<int> bookIDs, string bookStatus)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (int id in bookIDs)
                {
                    Console.WriteLine($"Delete book id {id}");
                    var values = new { bookID = id, bookStatus = bookStatus };
                    connection.Query("delete_book", values, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
        }


        public static void changeMediaStatus(MediaTypeNames mediaTypeID, int mediaID, string status)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { mediaTypeID = mediaTypeID, mediaID = mediaID, newStatus = status };
                connection.Query("change_media_status", values, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void changeBookTitle(int bookID, string newTitle)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { book_id = bookID, title = newTitle };
                connection.Query("change_book_title", values, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void changeBookAuthor(int bookID, string newAuthor)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { book_id = bookID, author = newAuthor };
                connection.Query("change_book_author", values, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void changeBookGenres(int bookID, string newGenres)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { book_id = bookID, genres = newGenres };
                connection.Query("change_book_genre", values, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
