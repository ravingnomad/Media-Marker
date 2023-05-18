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

namespace Media_Edit_Forms
{
    public partial class MovieEditForm : Form
    {
        private int movieID;
        private string originalTitle;
        private string originalDirector;
        private HashSet<string> originalGenres;


        public MovieEditForm(Movie selectedMovie)
        {
            InitializeComponent();
            movieID = selectedMovie.movie_id;
            originalTitle = selectedMovie.title;
            originalDirector = selectedMovie.director;
            originalGenres = new HashSet<string>(selectedMovie.genres.Split('\n').ToList());

            movieEditTitleTextBox.Text = selectedMovie.title;
            movieEditDirectorTextBox.Text = selectedMovie.director;
            List<string> temp = selectedMovie.genres.Split('\n').ToList();

            List<int> indicesToCheck = new List<int>();

            foreach (string genre in movieEditGenreListBox.Items)
            {
                if (temp.Contains(genre.ToLower()))
                {
                    int location = movieEditGenreListBox.Items.IndexOf(genre);
                    indicesToCheck.Add(location);
                }
            }

            foreach (int location in indicesToCheck)
            {
                movieEditGenreListBox.SetItemChecked(location, true);
            }
        }


        private void movieEditSaveButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedFields = new Dictionary<string, string>();
            if (movieEditTitleTextBox.Text != originalTitle)
            {
                updatedFields.Add("Title", movieEditTitleTextBox.Text);
            }

            if (movieEditDirectorTextBox.Text != originalDirector)
            {
                updatedFields.Add("Director", movieEditDirectorTextBox.Text);
            }

            if (genresChanged())
            {
                List<string> genreList = new List<string>();
                foreach (string genre in movieEditGenreListBox.CheckedItems)
                {
                    genreList.Add(genre);
                }
                string newGenresString = String.Join(",", genreList);
                
                updatedFields.Add("Genre", newGenresString);
            }
            mysqlHelper.updateMovie(movieID, updatedFields);
        }

        private bool genresChanged()
        {
            //temporarily stores the genres that are check in the check list box
            List<string> temp = new List<string>();

            for (int index = 0; index < movieEditGenreListBox.Items.Count; index++)
            {
                if (movieEditGenreListBox.GetItemChecked(index) == true)
                    temp.Add(((string)movieEditGenreListBox.Items[index]).ToLower());
            }

            //use hash set to see if the original set of genres matches this new set of genres
            HashSet<string> placeHolder = new HashSet<string>(temp);
            return placeHolder.SetEquals(originalGenres) == false;

        }
    }
}
