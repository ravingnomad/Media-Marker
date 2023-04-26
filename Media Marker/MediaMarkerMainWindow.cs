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
using Media_Edit_Forms;

namespace Media_Marker
{
    public partial class MediaMarkerMainWindow : Form
    {
        bookSearchResultForm testForm;
        movieSearchResultForm movieTestForm;
        showSearchResultForm showTestForm;
        gameSearchResultForm gameTestForm;
        public MediaMarkerMainWindow()
        {
            InitializeComponent();

            possessedBookResultPanel.Controls.Clear();
            testForm = new bookSearchResultForm();
            testForm.TopLevel = false;
            possessedBookResultPanel.Controls.Add(testForm);

            possessedGameResultPanel.Controls.Clear();
            gameTestForm = new gameSearchResultForm();
            gameTestForm.TopLevel = false;
            possessedGameResultPanel.Controls.Add(gameTestForm);

            possessedMovieResultPanel.Controls.Clear();
            movieTestForm = new movieSearchResultForm();
            movieTestForm.TopLevel = false;
            possessedMovieResultPanel.Controls.Add(movieTestForm);

            possessedShowResultPanel.Controls.Clear();
            showTestForm = new showSearchResultForm();
            showTestForm.TopLevel = false;
            possessedShowResultPanel.Controls.Add(showTestForm);

            testForm.Show();
            movieTestForm.Show();
            showTestForm.Show();
            gameTestForm.Show();
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

            string mediaTypeString = mediaTabs.SelectedTab.Text;

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string checkedButton = bookSearchCriteriaRadioGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;

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

            string mediaTypeString = mediaTabs.SelectedTab.Text;

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

        private void possessedGameListAllButton_Click(object sender, EventArgs e)
        {
            List<Game> listAllResult = mysqlHelper.listAllGames("Possessed Game");
            gameTestForm.loadNewInfo(listAllResult);
            possessedGameResultPanel.Controls.Clear();
            gameTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameTestForm.Dock = DockStyle.Fill;
            gameTestForm.TopLevel = false;
            possessedGameResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
        }


        //referenced code https://stackoverflow.com/questions/1237829/datagridview-checkbox-column-value-and-functionality
        private void confirmActionButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> checkedValues = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in testForm.bookDataGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    checkedValues.Add(row);
                }
            }

            if (actionDropDownBox.Text == "Delete")
            {

                List<int> chosenBooks = new List<int>();
                foreach (DataGridViewRow row in checkedValues)
                {
                    chosenBooks.Add((int)row.Cells["book_id"].Value);
                }
                //mysqlHelper.deleteBooks(chosenBooks, "Possessed Media");
                testForm.deleteFromDataSource(checkedValues);
                possessedBookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                possessedBookResultPanel.Controls.Add(testForm);
                testForm.Show();
            }

            else if (actionDropDownBox.Text == "Move to \"Desired\" media" && dataBaseTabs.SelectedTab.Text == "Possessed Media")
            {
                foreach (DataGridViewRow row in checkedValues)
                {
                    //change this value in database
                    int bookID = (int)row.Cells["book_id"].Value;
                    Console.WriteLine(bookID);
                    mysqlHelper.changeMediaStatus(mysqlHelper.MediaTypeNames.Book, bookID, "Desired Media");
                    //delete this value in current datasource
                }
                testForm.deleteFromDataSource(checkedValues);
                possessedBookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                possessedBookResultPanel.Controls.Add(testForm);
                testForm.Show();
                Console.WriteLine("Move to desired table!");
            }

            else if (actionDropDownBox.Text == "Move to \"Possessed\" media" && dataBaseTabs.SelectedTab.Text == "Desired Media")
            {
                foreach (DataGridViewRow row in checkedValues)
                {
                    //change this value in database
                    int bookID = (int)row.Cells["book_id"].Value;
                    Console.WriteLine(bookID);
                    mysqlHelper.changeMediaStatus(mysqlHelper.MediaTypeNames.Book, bookID, "Possessed Media");
                    //delete this value in current datasource
                }
                testForm.deleteFromDataSource(checkedValues);
                possessedBookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                possessedBookResultPanel.Controls.Add(testForm);
                testForm.Show();
                Console.WriteLine("Move to possessed table!");
            }

            //to prevent user from being able to open multiple forms, look into making these forms a 'singleton'
            //https://stackoverflow.com/questions/2018272/preventing-multiple-instance-of-one-form-from-displaying
            //above reference might help

            //how would you have the edit window know which genre to make a check mark at? furthermore, how would you save the newly edited
            //info?
            else if (actionDropDownBox.Text == "Edit")
            {
                if (checkedValues.Count > 1)
                {
                    Console.WriteLine("ERROR: Only one media piece can be edited at a time!");
                }

                else
                {
                    DataGridViewRow selectedPiece = checkedValues[0];
                    Console.WriteLine($"Selected piece to edit: { selectedPiece.Cells["book_id"].Value }    {selectedPiece.Cells["title"].Value }   {selectedPiece.Cells["author"].Value }");
                    //call mysql function to get book(or other media info) and use that to pass into the edit form
                    Book selectedBook = mysqlHelper.getBook((int)selectedPiece.Cells["book_id"].Value);
                    //Console.WriteLine(selectedBook.fullString);
                    bookEditForm editForm = new bookEditForm(selectedBook);
                    editForm.Show();
                }
            }
        }

        private void possessedMovieListAllButton_Click(object sender, EventArgs e)
        {
            List<Movie> listAllResult = mysqlHelper.listAllMovies("Possessed Movie");
            movieTestForm.loadNewInfo(listAllResult);
            possessedMovieResultPanel.Controls.Clear();
            movieTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movieTestForm.Dock = DockStyle.Fill;
            movieTestForm.TopLevel = false;
            possessedMovieResultPanel.Controls.Add(movieTestForm);
            gameTestForm.Show();
        }

        private void possessedShowListAllButton_Click(object sender, EventArgs e)
        {
            List<Show> listAllResult = mysqlHelper.listAllShows("Possessed Show");
            foreach (Show show in listAllResult)
            {
                Console.WriteLine(show.episodes);
            }
            showTestForm.loadNewInfo(listAllResult);
            possessedShowResultPanel.Controls.Clear();
            showTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            showTestForm.Dock = DockStyle.Fill;
            showTestForm.TopLevel = false;
            possessedShowResultPanel.Controls.Add(showTestForm);
            showTestForm.Show();
        }

        
        private void newBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            if (newBookRadioButton.Checked)
            {
                newBookForm newBook = new newBookForm();
                newEntryPanel.Controls.Clear();
                newBook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newBook.Dock = DockStyle.Fill;
                newBook.TopLevel = false;
                newEntryPanel.Controls.Add(newBook);
                newBook.Show();
            }
        }

        private void newMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newMovieRadioButton.Checked)
            {
                newMovieForm newMovie = new newMovieForm();
                newEntryPanel.Controls.Clear();
                newMovie.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newMovie.Dock = DockStyle.Fill;
                newMovie.TopLevel = false;
                newEntryPanel.Controls.Add(newMovie);
                newMovie.Show();
            }
        }

        private void newShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newShowRadioButton.Checked)
            {
                newShowForm newShow = new newShowForm("temp");
                newEntryPanel.Controls.Clear();
                newShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newShow.Dock = DockStyle.Fill;
                newShow.TopLevel = false;
                newEntryPanel.Controls.Add(newShow);
                newShow.Show();
            }
        }

        private void newGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newGameRadioButton.Checked)
            {
                newGameForm newGame = new newGameForm();
                newEntryPanel.Controls.Clear();
                newGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newGame.Dock = DockStyle.Fill;
                newGame.TopLevel = false;
                newEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }

        /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
        private string getRadioButtonInGroupBox(GroupBox groupBox)
        {
            string returnString = "";
            try
            {
                returnString = groupBox.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;
            }

            catch (NullReferenceException e)
            {
            }

            return returnString;
        }
    }
}
