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
            if (hasError() == false)
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
        }

        private bool hasError()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HelperLibrary.HelperFuncs.textBoxIsEmpty(newGameTitleTextBox, newGameDeveloperTextBox))
                errorMessage.Append("'Title' and 'Developer' fields must both have a value.\n");

            if (HelperLibrary.HelperFuncs.checkListBoxIsEmpty(gameGenreListBox) ||
                HelperLibrary.HelperFuncs.checkListBoxIsEmpty(gamePlatformListBox))
                errorMessage.Append("There must be at least 1 'Genre' and 1 'Platform' selected.\n");

            if (newGameTitleTextBox.Text != "" &&
                mysqlHelper.getMediaPieceTitle(HelperLibrary.MediaTypeNames.Video_Game, newGameTitleTextBox.Text) != "")
                errorMessage.Append("'Title' must be unique.\n");

            if (HelperLibrary.HelperFuncs.getRadioButtonInGroupBox(newGameStatusGroupBox) == "")
                errorMessage.Append("A 'Status' for this media piece must be selected\n");

            if (errorMessage.Length != 0)
                MessageBox.Show(errorMessage.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return errorMessage.Length != 0;
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
