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


        static public void connect()
        {
            loadConnString();
            using (MySqlConnection tempConnection = new MySqlConnection(connString))
            {

                
            }
        }
    }
}
