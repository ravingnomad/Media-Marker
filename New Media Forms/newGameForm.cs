using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql_Helper;

namespace New_Media_Forms
{
    public partial class newGameForm : Form
    {
        private string originTab;
        public newGameForm()
        {
            InitializeComponent();
        }

        private void addNewGameButton_Click(object sender, EventArgs e)
        {
            string gameTitle = newGameTitleTextBox.Text;
            string gameDeveloper = newGameDeveloperTextBox.Text;
            var gameGenres = gameGenreListBox.CheckedItems;
            var gamePlatforms = gamePlatformListBox.CheckedItems;

            List<string> newGameGenresList = new List<string>();
            List<string> newGamePlatformsList = new List<string>();
            foreach (string genre in gameGenres)
            {
                newGameGenresList.Add(genre);
            }
            foreach (string platform in gamePlatforms)
            {
                newGamePlatformsList.Add(platform);
            }

            mysqlHelper.addNewGame(gameTitle, gameDeveloper, newGameGenresList, newGamePlatformsList, originTab);
        }
    }
}
