﻿using System;
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
                var value = new {bookID = bookID};
                Book result = connection.Query<Book>("get_book", value, commandType: System.Data.CommandType.StoredProcedure).ToList()[0];
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
    }
}
