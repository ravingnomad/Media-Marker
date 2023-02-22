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
    }
}
