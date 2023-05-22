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
    public partial class ShowEditForm : Form
    {
        private int showID;
        private string originalTitle;
        private string originalDirector;
        private int originalSeasons;
        private int originalEpisodes;
        private HashSet<string> originalGenres;

        public ShowEditForm(Show selectedShow)
        {
            InitializeComponent();
            showID = selectedShow.tv_show_id;
            originalTitle = selectedShow.title;
            originalDirector = selectedShow.director;
            originalSeasons = selectedShow.seasons;
            originalEpisodes = selectedShow.episodes;
            originalGenres = new HashSet<string>(selectedShow.genres.Split('\n').ToList());

            showEditTitleTextBox.Text = selectedShow.title;
            showEditDirectorTextBox.Text = selectedShow.director;
            showEditSeasonTextBox.Text = selectedShow.seasons.ToString();
            showEditEpisodesTextBox.Text = selectedShow.episodes.ToString();
            List<string> temp = selectedShow.genres.Split('\n').ToList();

            List<int> indicesToCheck = new List<int>();

            foreach (string genre in showEditGenreListBox.Items)
            {
                if (temp.Contains(genre.ToLower()))
                {
                    int location = showEditGenreListBox.Items.IndexOf(genre);
                    indicesToCheck.Add(location);
                }
            }

            foreach (int location in indicesToCheck)
            {
                showEditGenreListBox.SetItemChecked(location, true);
            }
        }

        private void showEditSaveButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedFields = new Dictionary<string, string>();
            if (showEditTitleTextBox.Text != originalTitle)
            {
                updatedFields.Add("Title", showEditTitleTextBox.Text);
            }

            if (showEditDirectorTextBox.Text != originalDirector)
            {
                updatedFields.Add("Director", showEditDirectorTextBox.Text);
            }

            if (Int32.Parse(showEditSeasonTextBox.Text) != originalSeasons)
            {
                updatedFields.Add("Seasons", showEditSeasonTextBox.Text);
            }

            if (Int32.Parse(showEditEpisodesTextBox.Text) != originalEpisodes)
            {
                updatedFields.Add("Episodes", showEditEpisodesTextBox.Text);
            }

            if (genresChanged())
            {
                List<string> genreList = new List<string>();
                foreach (string genre in showEditGenreListBox.CheckedItems)
                {
                    genreList.Add(genre);
                }
                string newGenresString = String.Join(",", genreList);

                updatedFields.Add("Genre", newGenresString);
            }
            mysqlHelper.updateMediaPiece(HelperLibrary.MediaTypeNames.TV_Show, showID, updatedFields);
            this.Close();
        }

        private bool genresChanged()
        {
            return HelperLibrary.HelperFuncs.checkListBoxChanged(showEditGenreListBox, originalGenres);
        }
    }
}
