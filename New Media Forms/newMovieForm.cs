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
    public partial class newMovieForm : Form
    {
        private string originTab;
        public newMovieForm()
        {
            InitializeComponent();
        }

        private void addNewMovieButton_Click(object sender, EventArgs e)
        {
            string movieTitle = newMovieTitleTextBox.Text;
            string directorName = newMovieDirectorTextBox.Text;
            var newMovieGenres = newMovieGenreListBox.CheckedItems;

            List<string> newMovieGenresList = new List<string>();
            foreach (string genre in newMovieGenres)
            {
                newMovieGenresList.Add(genre);
            }
            mysqlHelper.addNewMovie(movieTitle, directorName, newMovieGenresList, originTab);
        }
    }
}
