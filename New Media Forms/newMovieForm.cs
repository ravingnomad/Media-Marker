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
    public partial class NewMovieForm : Form
    {
        public NewMovieForm()
        {
            InitializeComponent();
        }

        private void addNewMovieButton_Click(object sender, EventArgs e)
        {
            if (hasError() == false)
            {
                string movieTitle = newMovieTitleTextBox.Text;
                string directorName = newMovieDirectorTextBox.Text;
                var newMovieGenres = newMovieGenreListBox.CheckedItems;
                string newMovieStatusString = HelperFuncs.getRadioButtonInGroupBox(newMovieStatusGroupBox);
                HelperLibrary.MediaStatus newMovieStatusEnum = (newMovieStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;

                List<string> newMovieGenresList = new List<string>();
                foreach (string genre in newMovieGenres)
                {
                    newMovieGenresList.Add(genre);
                }
                mysqlHelper.addNewMovie(movieTitle, directorName, newMovieGenresList, newMovieStatusEnum);
                resetForm();
            }
        }

        private bool hasError()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HelperLibrary.HelperFuncs.textBoxIsEmpty(newMovieTitleTextBox, newMovieDirectorTextBox))
                errorMessage.Append("'Title' and 'Director' fields must both have a value.\n");

            if (HelperLibrary.HelperFuncs.checkListBoxIsEmpty(newMovieGenreListBox))
                errorMessage.Append("There must be at least 1 genre selected.\n");

            if (newMovieTitleTextBox.Text != "" &&
                mysqlHelper.getMediaPieceTitle(HelperLibrary.MediaTypeNames.Movie, newMovieTitleTextBox.Text) != "")
                errorMessage.Append("Title must be unique.\n");

            if (HelperLibrary.HelperFuncs.getRadioButtonInGroupBox(newMovieStatusGroupBox) == "")
                errorMessage.Append("A 'Status' for this media piece must be selected\n");

            if (errorMessage.Length != 0)
                MessageBox.Show(errorMessage.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return errorMessage.Length != 0;
        }

        private void resetForm()
        {
            newMovieTitleTextBox.Clear();
            newMovieDirectorTextBox.Clear();
            foreach (int index in newMovieGenreListBox.CheckedIndices)
            {
                newMovieGenreListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
            newMoviePossessedRadioButton.Checked = false;
            newMovieDesiredRadioButton.Checked = false;
        }
    }
}
