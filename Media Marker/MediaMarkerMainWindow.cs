using Media_Search_Result_Forms;
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
using MySql_Helper;
using Media_Types;

namespace Media_Marker
{
    public partial class MediaMarkerMainWindow : Form
    {
        bookSearchResultForm testForm;
        public MediaMarkerMainWindow()
        {
            InitializeComponent();
            possessedBookResultPanel.Controls.Clear();
            testForm = new bookSearchResultForm();
            testForm.TopLevel = false;
            possessedBookResultPanel.Controls.Add(testForm);
            
            testForm.Show();
        }

        private void newDesiredBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredBookRadioButton.Checked)
            {
                newDesiredEntryPanel.Controls.Clear();
                newBookForm newBook = new newBookForm("Desired Media");
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
                newMovieForm newMovie = new newMovieForm("Desired Media");
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
                newShowForm newShow = new newShowForm("Desired Media");
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
                newGameForm newGame = new newGameForm("Desired Media");
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
                newBookForm newBook = new newBookForm("Possessed Media");
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
                newMovieForm newMovie = new newMovieForm("Possessed Media");
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
                newShowForm newShow = new newShowForm("Possessed Media");
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
                newGameForm newGame = new newGameForm("Possessed Media");
                newGame.TopLevel = false;
                newGame.Dock = DockStyle.Fill;
                newPossessedEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }

        private void MediaMarkerMainWindow_Load(object sender, EventArgs e)
        {
            possessedBookResultPanel.Controls.Clear();
            bookSearchResultForm possessedBookResults = new bookSearchResultForm();
            possessedBookResults.TopLevel = false;
            possessedBookResults.Dock = DockStyle.Fill;
            possessedBookResultPanel.Controls.Add(possessedBookResults);
            possessedBookResults.Show();
        }

        private void possessedBookSearchButton_Click(object sender, EventArgs e)
        {
            //type if System.Windows.Forms.TabPage
            //get tab page of database tab (whether it is 'possessed' or 'desired'
            //get tab page of 'desired' or 'possessed' tab (whether it is a 'book', 'movie' 'show' or 'game')
            string mediaStatusString = dataBaseTabs.SelectedTab.Text;

            string mediaTypeString = possessedMediaTabs.SelectedTab.Text;

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string checkedButton = possessedBookRadioGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;

            string searchQuery = possessedBookSearchTextBox.Text;

            List<Book> searchResults = mysqlHelper.searchMedia(mediaStatusString, mediaTypeString, checkedButton, searchQuery);

            possessedBookResultPanel.Controls.Clear();
            testForm.loadSearchResults(searchResults);
            testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testForm.Dock = DockStyle.Fill;
            testForm.TopLevel = false;
            possessedBookResultPanel.Controls.Add(testForm);
            testForm.Show();
        }

        private void possessedMovieSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = dataBaseTabs.SelectedTab.Text;

            string mediaTypeString = possessedMediaTabs.SelectedTab.Text;

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string checkedButton = possessedMoviesRadioGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;

            string searchQuery = possessedMovieSearchTextBox.Text;

            List<Book> searchResults = mysqlHelper.searchMedia(mediaStatusString, mediaTypeString, checkedButton, searchQuery);
            
        }

        private void possessedBookListAllButton_Click(object sender, EventArgs e)
        {
            List<Book> listAllResult = mysqlHelper.listAllBooks("Possessed Book");
            testForm.loadNewInfo(listAllResult);
            possessedBookResultPanel.Controls.Clear();
            testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testForm.Dock = DockStyle.Fill;
            testForm.TopLevel = false;
            possessedBookResultPanel.Controls.Add(testForm);
            testForm.Show();
        }
    }
}
