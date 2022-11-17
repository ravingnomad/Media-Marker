using New_Media_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Marker
{
    public partial class MediaMarkerMainWindow : Form
    {
        public MediaMarkerMainWindow()
        {
            InitializeComponent();
        }

        private void newDesiredBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredBookRadioButton.Checked)
            {
                newBookForm newBook = new newBookForm();
                newBook.Show();
            }
        }

        private void newDesiredMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredMovieRadioButton.Checked)
            {
                newMovieForm newMovie = new newMovieForm();
                newMovie.Show();
            }
        }

        private void newDesiredShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredShowRadioButton.Checked)
            {
                newShowForm newShow = new newShowForm();
                newShow.Show();
            }
        }

        private void newDesiredGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredGameRadioButton.Checked)
            {
                newGameForm newGame = new newGameForm();
                newGame.Show();
            }
        }




        private void addNewDesiredEntryTabPage_Click(object sender, EventArgs e)
        {
        }

        private void newPossessedBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedBookRadioButton.Checked)
            {
                newBookForm newBook = new newBookForm();
                newBook.Show();
            }
        }

        private void newPossessedMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedMovieRadioButton.Checked)
            {
                newMovieForm newMovie = new newMovieForm();
                newMovie.Show();
            }
        }

        private void newPossessedShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedShowRadioButton.Checked)
            {
                newShowForm newShow = new newShowForm();
                newShow.Show();
            }
        }

        private void newPossessedGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedGameRadioButton.Checked)
            {
                newGameForm newGame = new newGameForm();
                newGame.Show();
            }
        }
    }
}
