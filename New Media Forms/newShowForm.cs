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
