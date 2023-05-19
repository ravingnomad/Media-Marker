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
using HelperLibrary;

namespace New_Media_Forms
{
    public partial class NewGameForm : Form
    {
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void addNewGameButton_Click(object sender, EventArgs e)
        {
            string gameTitle = newGameTitleTextBox.Text;
            string gameDeveloper = newGameDeveloperTextBox.Text;
            string newGameStatusString = HelperFuncs.getRadioButtonInGroupBox(newGameStatusGroupBox);
            HelperLibrary.MediaStatus newGameStatusEnum = (newGameStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;
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

            mysqlHelper.addNewGame(gameTitle, gameDeveloper, newGameGenresList, newGamePlatformsList, newGameStatusEnum);
            resetForm();
        }

        private void resetForm()
        {
            newGameTitleTextBox.Clear();
            newGameDeveloperTextBox.Clear();
            newGamePossessedRadioButton.Checked = false;
            newGameDesiredRadioButton.Checked = false;
            foreach (int index in gameGenreListBox.CheckedIndices)
            {
                gameGenreListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
            foreach (int index in gamePlatformListBox.CheckedIndices)
            {
                gamePlatformListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
        }
    }
}
