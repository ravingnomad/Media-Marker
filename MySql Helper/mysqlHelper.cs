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


        public static void addNewBook(string bookTitle, string author, List<string> bookGenres, Enums.MediaStatus mediaStatus)
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
                    mediaStatus = mediaStatus
                };
                connection.Query("insert_book", bookValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void addNewMovie(string movieTitle, string director, List<string> movieGenres, Enums.MediaStatus mediaStatus)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new movie and its genre info to the database
                string movieGenresString = String.Join(",", movieGenres);
                var movieValues = new { mediaTypeID = MediaTypeNames.Movie,
                    movieTitle = movieTitle,
                    director = director,
                    movieGenresString = movieGenresString,
                    mediaStatus = mediaStatus
                };
                connection.Query("insert_movie", movieValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void addNewShow(string newShowTitle, string showDirector, int seasons, int episodes, List<string> showGenres, Enums.MediaStatus mediaStatus)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                //Add a new show and its genre info to the database
                string showGenresString = String.Join(",", showGenres);
                var showValues = new { mediaTypeID = MediaTypeNames.TV_Show,
                    showTitle = newShowTitle,
                    director = showDirector,
                    seasons = seasons,
                    episodes = episodes,
                    showGenresString = showGenresString,
                    mediaStatus = mediaStatus
                };
                connection.Query("insert_show", showValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public static void addNewGame(string newGameTitle, string newGameDeveloper, List<string> gameGenres, List<string> gamePlatforms, Enums.MediaStatus mediaStatus)
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
                    mediaStatus = mediaStatus };

                connection.Query("insert_game", gameValues, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static List<Book> searchBook(Enums.MediaStatus mediaStatus, Enums.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new {
                    bookStatus = mediaStatus,
                    searchField = selectedCriteria,
                    searchQuery = searchQuery
                };
                List<Book> result = connection.Query<Book>("search_book", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public static List<Movie> searchMovie(Enums.MediaStatus mediaStatus, Enums.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new
                {
                    movieStatus = mediaStatus,
                    searchField = selectedCriteria,
                    searchQuery = searchQuery
                };
                List<Movie> result = connection.Query<Movie>("search_movie", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public static List<Show> searchShow(Enums.MediaStatus mediaStatus, Enums.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new
                {
                    showStatus = mediaStatus,
                    searchField = selectedCriteria,
                    searchQuery = searchQuery
                };
                List<Show> result = connection.Query<Show>("search_show", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public static List<Game> searchGame(Enums.MediaStatus mediaStatus, Enums.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new
                {
                    gameStatus = mediaStatus,
                    searchField = selectedCriteria,
                    searchQuery = searchQuery
                };
                List<Game> result = connection.Query<Game>("search_video_game", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
                var value = new { bookID = bookID };
                Book result = connection.Query<Book>("get_book", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                return result;
            }
        }

        public static Movie getMovie(int movieID)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var value = new { movieID = movieID };
                Movie result = connection.Query<Movie>("get_movie", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                return result;
            }
        }

        public static Game getGame(int gameID)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var value = new { gameID = gameID };
                Game result = connection.Query<Game>("get_game", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                return result;
            }
        }

        public static Show getShow(int showID)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var value = new { showID = showID };
                Show result = connection.Query<Show>("get_show", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
                return result;
            }
        }


        public static List<Book> listAllBooks(Enums.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { bookEnum = Enums.MediaTypeNames.Book, mediaStatusEnum = statusIdentifier };

                List<Book> result = connection.Query<Book>("list_all_books", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Game> listAllGames(Enums.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { mediaStatusEnum = statusIdentifier};

                List<Game> result = connection.Query<Game>("list_all_games", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Movie> listAllMovies(Enums.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { movieEnum = Enums.MediaTypeNames.Movie, mediaStatusEnum = statusIdentifier };

                List<Movie> result = connection.Query<Movie>("list_all_movies", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Show> listAllShows(Enums.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { showEnum = Enums.MediaTypeNames.TV_Show, mediaStatusEnum = statusIdentifier };
                Console.WriteLine("Clicked in possessed show");
                List<Show> result = connection.Query<Show>("list_all_shows", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }


        public static void deleteMediaPieces(List<int> mediaIDs, string mediaTypeString)
        {
            if (connString == null)
            {
                loadConnString();
            }

            Enums.MediaTypeNames mediaTypeEnum = getMediaTypeEnum(mediaTypeString);

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (int id in mediaIDs)
                {
                    if (mediaTypeString == "Books")
                    {
                        var values = new { bookEnum = mediaTypeEnum, bookID = id };
                        connection.Query("delete_book", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    if (mediaTypeString == "Movies")
                    {
                        var values = new { movieEnum = mediaTypeEnum, movieID = id };
                        connection.Query("delete_movie", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    if (mediaTypeString == "Shows")
                    {
                        var values = new { showEnum = mediaTypeEnum, showID = id };
                        connection.Query("delete_show", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                    if (mediaTypeString == "Games")
                    {
                        var values = new { gameEnum = mediaTypeEnum, gameID = id };
                        connection.Query("delete_game", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                }
            }
        }


        private static Enums.MediaTypeNames getMediaTypeEnum(string mediaTypeString)
        {
            if (mediaTypeString == "Books")
                return Enums.MediaTypeNames.Book;
            else if (mediaTypeString == "Movies")
                return Enums.MediaTypeNames.Movie;
            else if (mediaTypeString == "Shows")
                return Enums.MediaTypeNames.TV_Show;
            return Enums.MediaTypeNames.Video_Game;
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


        public static void updateBook(int bookID, Dictionary<string, string> updatedValues)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (KeyValuePair<string, string> field in updatedValues)
                {
                    if (field.Key == "Genre")
                    {
                        var values = new { mediaTypeEnum = Enums.MediaTypeNames.Book, mediaPieceID = bookID, genres = field.Value };
                        connection.Query("change_media_genre", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    else
                    {
                        var values = new { book_id = bookID, fieldToChange = field.Key, newValue = field.Value };
                        connection.Query("update_book", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            }
        }

        public static void updateMovie(int movieID, Dictionary<string, string> updatedValues)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (KeyValuePair<string, string> field in updatedValues)
                {
                    if (field.Key == "Genre")
                    {
                        var values = new { mediaTypeEnum = Enums.MediaTypeNames.Movie, mediaPieceID = movieID, genres = field.Value };
                        connection.Query("change_media_genre", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    else
                    {
                        var values = new { movie_id = movieID, fieldToChange = field.Key, newValue = field.Value };
                        connection.Query("update_movie", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            }
        }

        public static void updateShow(int showID, Dictionary<string, string> updatedValues)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (KeyValuePair<string, string> field in updatedValues)
                {
                    if (field.Key == "Genre")
                    {
                        var values = new { mediaTypeEnum = Enums.MediaTypeNames.TV_Show, mediaPieceID = showID, genres = field.Value };
                        connection.Query("change_media_genre", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    else if (field.Key == "Seasons" || field.Key == "Episodes")
                    {
                        var values = new { show_id = showID, fieldToChange = field.Key, newStringValue = "", newIntValue = Int32.Parse(field.Value) };
                        connection.Query("update_show", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    else
                    {
                        var values = new { show_id = showID, fieldToChange = field.Key, newStringValue = field.Value, newIntValue = 0};
                        connection.Query("update_show", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            }
        }

        public static void updateGame(int gameID, Dictionary<string, string> updatedValues)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (KeyValuePair<string, string> field in updatedValues)
                {
                    if (field.Key == "Genre")
                    {
                        var values = new { mediaTypeEnum = Enums.MediaTypeNames.Video_Game, mediaPieceID = gameID, genres = field.Value };
                        connection.Query("change_media_genre", values, commandType: System.Data.CommandType.StoredProcedure);
                    }

                    else
                    {
                        var values = new { game_id = gameID, fieldToChange = field.Key, newValue = field.Value};
                        Console.WriteLine($"KEY: {field.Key}    VALUE: {field.Value}");
                        connection.Query("update_game", values, commandType: System.Data.CommandType.StoredProcedure);
                    }
                }
            }
        }
    }
}
