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
            possessedBookResultPanel.Controls.Clear();
            
        }

        private void newDesiredBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredBookRadioButton.Checked)
            {
                newDesiredEntryPanel.Controls.Clear();
                newBookForm newBook = new newBookForm();
                newBook.TopLevel = false;
                newBook.Dock = DockStyle.Fill;
                newDesiredEntryPanel.Controls.Add(newBook);
                newBook.Show();
            }
        }

        private void newDesiredMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredMovieRadioButton.Checked)
            {
                newDesiredEntryPanel.Controls.Clear();
                newMovieForm newMovie = new newMovieForm();
                newMovie.TopLevel = false;
                newMovie.Dock = DockStyle.Fill;
                newDesiredEntryPanel.Controls.Add(newMovie);
                newMovie.Show();
            }
        }

        private void newDesiredShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredShowRadioButton.Checked)
            {
                newDesiredEntryPanel.Controls.Clear();
                newShowForm newShow = new newShowForm();
                newShow.TopLevel = false;
                newShow.Dock = DockStyle.Fill;
                newDesiredEntryPanel.Controls.Add(newShow);
                newShow.Show();
            }
        }

        private void newDesiredGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredGameRadioButton.Checked)
            {
                newDesiredEntryPanel.Controls.Clear();
                newGameForm newGame = new newGameForm();
                newGame.TopLevel = false;
                newGame.Dock = DockStyle.Fill;
                newDesiredEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }


        private void newPossessedBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedBookRadioButton.Checked)
            {
                newPossessedEntryPanel.Controls.Clear();
                newBookForm newBook = new newBookForm();
                newBook.TopLevel = false;
                newBook.Dock = DockStyle.Fill;
                newPossessedEntryPanel.Controls.Add(newBook);
                newBook.Show();
            }
        }


        private void newPossessedMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedMovieRadioButton.Checked)
            {
                newPossessedEntryPanel.Controls.Clear();
                newMovieForm newMovie = new newMovieForm();
                newMovie.TopLevel = false;
                newMovie.Dock = DockStyle.Fill;
                newPossessedEntryPanel.Controls.Add(newMovie);
                newMovie.Show();
            }
        }

        private void newPossessedShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedShowRadioButton.Checked)
            {
                newPossessedEntryPanel.Controls.Clear();
                newShowForm newShow = new newShowForm();
                newShow.TopLevel = false;
                newShow.Dock = DockStyle.Fill;
                newPossessedEntryPanel.Controls.Add(newShow);
                newShow.Show();
            }
        }

        private void newPossessedGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newPossessedGameRadioButton.Checked)
            {
                newPossessedEntryPanel.Controls.Clear();
                newGameForm newGame = new newGameForm();
                newGame.TopLevel = false;
                newGame.Dock = DockStyle.Fill;
                newPossessedEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }
    }
}
