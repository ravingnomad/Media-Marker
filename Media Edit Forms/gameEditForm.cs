using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Media_Types;
using MySql_Helper;
using HelperLibrary;

namespace Media_Edit_Forms
{
    public partial class GameEditForm : Form
    {

        private int gameID;
        private string originalTitle;
        private string originalDeveloper;
        private HashSet<string> originalGenres;
        private HashSet<string> originalPlatforms;

        public GameEditForm(Game selectedGame)
        {
            InitializeComponent();

            gameID = selectedGame.video_game_id;
            originalTitle = selectedGame.title;
            originalDeveloper = selectedGame.developer;
            originalGenres = new HashSet<string>(selectedGame.genres.Split('\n').ToList());
            originalPlatforms = new HashSet<string>(selectedGame.platforms.Split('\n').ToList());

            gameEditTitleTextBox.Text = selectedGame.title;
            gameEditDeveloperTextBox.Text = selectedGame.developer;

            List<string> tempGenres = selectedGame.genres.Split('\n').ToList();
            List<string> tempPlatforms = selectedGame.platforms.Split('\n').ToList();

            List<int> genreIndicesToCheck = new List<int>();
            List<int> platformIndicesToCheck = new List<int>();

            foreach (string genre in gameEditGenreListBox.Items)
            {
                if (tempGenres.Contains(genre.ToLower()))
                {
                    int location = gameEditGenreListBox.Items.IndexOf(genre);
                    genreIndicesToCheck.Add(location);
                }
            }

            foreach (string platform in gameEditPlatformListBox.Items)
            {
                if (tempPlatforms.Contains(platform))
                {
                    int location = gameEditPlatformListBox.Items.IndexOf(platform);
                    platformIndicesToCheck.Add(location);
                }
            }

            foreach (int location in genreIndicesToCheck)
            {
                gameEditGenreListBox.SetItemChecked(location, true);
            }

            foreach (int location in platformIndicesToCheck)
            {
                gameEditPlatformListBox.SetItemChecked(location, true);
            }
        }

        private void gameEditSaveButton_Click(object sender, EventArgs e)
        {
            if (hasError() == false)
            {
                Dictionary<string, string> updatedFields = new Dictionary<string, string>();
                if (gameEditTitleTextBox.Text != originalTitle)
                {
                    updatedFields.Add("Title", gameEditTitleTextBox.Text);
                }

                if (gameEditDeveloperTextBox.Text != originalDeveloper)
                {
                    updatedFields.Add("Developer", gameEditDeveloperTextBox.Text);
                }

                if (platformsChanged())
                {
                    List<string> platformList = new List<string>();
                    foreach (string platform in gameEditPlatformListBox.CheckedItems)
                    {
                        platformList.Add(platform);
                    }
                    string newPlatformsString = String.Join(",", platformList);
                    updatedFields.Add("Platforms", newPlatformsString);
                }

                if (genresChanged())
                {
                    List<string> genreList = new List<string>();
                    foreach (string genre in gameEditGenreListBox.CheckedItems)
                    {
                        genreList.Add(genre);
                    }
                    string newGenresString = String.Join(",", genreList);

                    updatedFields.Add("Genre", newGenresString);
                }
                mysqlHelper.updateMediaPiece(HelperLibrary.MediaTypeNames.Video_Game, gameID, updatedFields);
                this.Close();
            }
        }


        private bool hasError()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HelperLibrary.HelperFuncs.textBoxIsEmpty(gameEditTitleTextBox, gameEditDeveloperTextBox))
                errorMessage.Append("'Title' and 'Developer' fields must both have a value.\n");

            if (HelperLibrary.HelperFuncs.checkListBoxIsEmpty(gameEditGenreListBox) ||
                HelperLibrary.HelperFuncs.checkListBoxIsEmpty(gameEditPlatformListBox))
                errorMessage.Append("There must be at least 1 'Genre' and 1 'Platform' selected.\n");

            if (gameEditTitleTextBox.Text != originalTitle &&
                mysqlHelper.getMediaPieceTitle(HelperLibrary.MediaTypeNames.Video_Game, gameEditTitleTextBox.Text) != "")
                errorMessage.Append("'Title' must be unique.\n");

            if (errorMessage.Length != 0)
                MessageBox.Show(errorMessage.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return errorMessage.Length != 0;
        }

        private bool genresChanged()
        {
            return HelperLibrary.HelperFuncs.checkListBoxChanged(gameEditGenreListBox, originalGenres);
        }

        private bool platformsChanged()
        {
            return HelperLibrary.HelperFuncs.checkListBoxChanged(gameEditPlatformListBox, originalPlatforms);
        }
    }
}
