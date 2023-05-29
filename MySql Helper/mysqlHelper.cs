using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Media_Types;
using HelperLibrary;

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


        public static void addNewBook(string bookTitle, string author, List<string> bookGenres, HelperLibrary.MediaStatus mediaStatus)
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

        public static void addNewMovie(string movieTitle, string director, List<string> movieGenres, HelperLibrary.MediaStatus mediaStatus)
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


        public static void addNewShow(string newShowTitle, string showDirector, int seasons, int episodes, List<string> showGenres, HelperLibrary.MediaStatus mediaStatus)
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

        public static void addNewGame(string newGameTitle, string newGameDeveloper, List<string> gameGenres, List<string> gamePlatforms, HelperLibrary.MediaStatus mediaStatus)
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


        public static List<Book> searchBook(HelperLibrary.MediaStatus mediaStatus, HelperLibrary.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
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


        public static List<Movie> searchMovie(HelperLibrary.MediaStatus mediaStatus, HelperLibrary.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
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


        public static List<Show> searchShow(HelperLibrary.MediaStatus mediaStatus, HelperLibrary.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
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


        public static List<Game> searchGame(HelperLibrary.MediaStatus mediaStatus, HelperLibrary.MediaTypeNames mediaType, string selectedCriteria, string searchQuery)
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


        public static List<Book> listAllBooks(HelperLibrary.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { bookEnum = HelperLibrary.MediaTypeNames.Book, mediaStatusEnum = statusIdentifier };

                List<Book> result = connection.Query<Book>("list_all_books", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Game> listAllGames(HelperLibrary.MediaStatus statusIdentifier)
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

        public static List<Movie> listAllMovies(HelperLibrary.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { movieEnum = HelperLibrary.MediaTypeNames.Movie, mediaStatusEnum = statusIdentifier };

                List<Movie> result = connection.Query<Movie>("list_all_movies", values, commandType: System.Data.CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public static List<Show> listAllShows(HelperLibrary.MediaStatus statusIdentifier)
        {
            if (connString == null)
            {
                loadConnString();
            }
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { showEnum = HelperLibrary.MediaTypeNames.TV_Show, mediaStatusEnum = statusIdentifier };
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

            HelperLibrary.MediaTypeNames mediaTypeEnum = HelperLibrary.HelperFuncs.getMediaTypeEnum(mediaTypeString);

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

        public static void changeMediaStatus(HelperLibrary.MediaTypeNames mediaTypeID, int mediaID, HelperLibrary.MediaStatus status)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                var values = new { mediaType = mediaTypeID, mediaID = mediaID, newStatus = status };
                connection.Query("change_media_status", values, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        public static void updateMediaPiece(HelperLibrary.MediaTypeNames mediaTypeEnum, int mediaID, Dictionary<string, string> updatedValues)
        {
            if (connString == null)
            {
                loadConnString();
            }

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                foreach (KeyValuePair<string, string> field in updatedValues)
                {
                    switch (field.Key)
                    {
                        case "Genre":
                            var changeGenreValues = new { mediaTypeEnum = mediaTypeEnum, mediaPieceID = mediaID, genres = field.Value };
                            connection.Query("change_media_genre", changeGenreValues, commandType: System.Data.CommandType.StoredProcedure);
                            break;
                        case "Seasons":
                        case "Episodes":
                            var changeIntValues = new { mediaTypeEnum = mediaTypeEnum, mediaID = mediaID, fieldToChange = field.Key, stringValue = "", intValue = Int32.Parse(field.Value)};
                            connection.Query("update_media_piece", changeIntValues, commandType: System.Data.CommandType.StoredProcedure);
                            break;
                        default:
                            var changeFieldValues = new { mediaTypeEnum = mediaTypeEnum, mediaID = mediaID, fieldToChange = field.Key, stringValue = field.Value, intValue = 0 };
                            connection.Query("update_media_piece", changeFieldValues, commandType: System.Data.CommandType.StoredProcedure);
                            break;
                    }
                }
            }
        }

        public static string getMediaPieceTitle(HelperLibrary.MediaTypeNames mediaTypeEnum, string title)
        {
            if (connString == null)
            {
                loadConnString();
            }
            string returnedTitle = "";
            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                switch (mediaTypeEnum)
                {
                    case HelperLibrary.MediaTypeNames.Book:
                        var bookValues = new { title = title };
                        Book tempBook = connection.QuerySingleOrDefault<Book>("get_book_title", bookValues, commandType: System.Data.CommandType.StoredProcedure);
                        returnedTitle = (tempBook == null ? "" : tempBook.title);
                        break;
                    case HelperLibrary.MediaTypeNames.Movie:
                        var movieValues = new { title = title };
                        Movie tempMovie = connection.QuerySingleOrDefault<Movie>("get_movie_title", movieValues, commandType: System.Data.CommandType.StoredProcedure);
                        returnedTitle = (tempMovie == null ? "" : tempMovie.title);
                        break;
                    case HelperLibrary.MediaTypeNames.TV_Show:
                        var showValues = new { title = title };
                        Show tempShow = connection.QuerySingleOrDefault<Show>("get_show_title", showValues, commandType: System.Data.CommandType.StoredProcedure);
                        returnedTitle = (tempShow == null ? "" : tempShow.title);
                        break;
                    case HelperLibrary.MediaTypeNames.Video_Game:
                        var gameValues = new { title = title };
                        Game tempGame = connection.QuerySingleOrDefault<Game>("get_game_title", gameValues, commandType: System.Data.CommandType.StoredProcedure);
                        returnedTitle = (tempGame == null ? "" : tempGame.title);
                        break;
                }
            }

            return returnedTitle;
        }
    }
}
