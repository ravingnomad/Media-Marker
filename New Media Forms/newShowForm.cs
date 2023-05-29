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
    public partial class NewShowForm : Form
    {
        public NewShowForm()
        {
            InitializeComponent();
        }
        private void addNewShowButton_Click(object sender, EventArgs e)
        {
            if (hasError() == false)
            { 
                string showTitle = newShowTitleTextBox.Text;
                string directorName = newShowDirectorTextBox.Text;
                string newShowStatusString = HelperFuncs.getRadioButtonInGroupBox(newShowStatusGroupBox);
                HelperLibrary.MediaStatus newShowStatusEnum = (newShowStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;
                int seasons = 0;
                int episodes = 0;
                if (newShowSeasonTextBox.Text != "")
                    seasons = Int32.Parse(newShowSeasonTextBox.Text);
                if (newShowEpisodesTextBox.Text != "")
                    episodes = Int32.Parse(newShowEpisodesTextBox.Text);

                var newShowGenres = showGenreListBox.CheckedItems;

                List<string> newShowGenresList = new List<string>();
                foreach (string genre in newShowGenres)
                {
                    newShowGenresList.Add(genre);
                }
                mysqlHelper.addNewShow(showTitle, directorName, seasons, episodes, newShowGenresList, newShowStatusEnum);
                resetForm();
            }
        }

        private bool hasError()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HelperLibrary.HelperFuncs.textBoxIsEmpty(newShowTitleTextBox, newShowDirectorTextBox))
                errorMessage.Append("'Title' and 'Director' fields must both have a value.\n");

            if (HelperLibrary.HelperFuncs.checkListBoxIsEmpty(showGenreListBox))
                errorMessage.Append("There must be at least 1 genre selected.\n");

            if (newShowTitleTextBox.Text != "" &&
                mysqlHelper.getMediaPieceTitle(HelperLibrary.MediaTypeNames.TV_Show, newShowTitleTextBox.Text) != "")
                errorMessage.Append("Title must be unique.\n");

            if (int.TryParse(newShowSeasonTextBox.Text.ToString(), out _) == false ||
                int.TryParse(newShowEpisodesTextBox.Text.ToString(), out _) == false)
                errorMessage.Append("'Seasons' and 'Episodes' must be an integer.\n");

            if (HelperLibrary.HelperFuncs.getRadioButtonInGroupBox(newShowStatusGroupBox) == "")
                errorMessage.Append("A 'Status' for this media piece must be selected\n");

            if (errorMessage.Length != 0)
                MessageBox.Show(errorMessage.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return errorMessage.Length != 0;
        }

        private void resetForm()
        {
            newShowTitleTextBox.Clear();
            newShowDirectorTextBox.Clear();
            foreach (int index in showGenreListBox.CheckedIndices)
            {
                showGenreListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
            newShowSeasonTextBox.Clear();
            newShowEpisodesTextBox.Clear();
            newShowPossessedRadioButton.Checked = false;
            newShowDesiredRadioButton.Checked = false;
        }
    }
}
