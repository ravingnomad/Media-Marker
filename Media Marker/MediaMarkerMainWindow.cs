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
using Enums;

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

            bookResultPanel.Controls.Clear();
            testForm = new bookSearchResultForm();
            testForm.TopLevel = false;
            bookResultPanel.Controls.Add(testForm);

            gameResultPanel.Controls.Clear();
            gameTestForm = new gameSearchResultForm();
            gameTestForm.TopLevel = false;
            gameResultPanel.Controls.Add(gameTestForm);

            movieResultPanel.Controls.Clear();
            movieTestForm = new movieSearchResultForm();
            movieTestForm.TopLevel = false;
            movieResultPanel.Controls.Add(movieTestForm);

            showResultPanel.Controls.Clear();
            showTestForm = new showSearchResultForm();
            showTestForm.TopLevel = false;
            showResultPanel.Controls.Add(showTestForm);

            testForm.Show();
            movieTestForm.Show();
            showTestForm.Show();
            gameTestForm.Show();
        }

        private void MediaMarkerMainWindow_Load(object sender, EventArgs e)
        {
            bookResultPanel.Controls.Clear();
            bookSearchResultForm possessedBookResults = new bookSearchResultForm();
            possessedBookResults.TopLevel = false;
            possessedBookResults.Dock = DockStyle.Fill;
            bookResultPanel.Controls.Add(possessedBookResults);
            possessedBookResults.Show();

            gameResultPanel.Controls.Clear();
            gameSearchResultForm gameResults = new gameSearchResultForm();
            gameResults.TopLevel = false;
            gameResults.Dock = DockStyle.Fill;
            gameResultPanel.Controls.Add(gameResults);
            gameResults.Show();

            movieResultPanel.Controls.Clear();
            movieSearchResultForm movieResults = new movieSearchResultForm();
            movieResults.TopLevel = false;
            movieResults.Dock = DockStyle.Fill;
            movieResultPanel.Controls.Add(movieResults);
            movieResults.Show();

            showResultPanel.Controls.Clear();
            showSearchResultForm showResults = new showSearchResultForm();
            showResults.TopLevel = false;
            showResults.Dock = DockStyle.Fill;
            showResultPanel.Controls.Add(showResults);
            showResults.Show();
        }


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

        private Enums.MediaStatus getMediaStatusEnum(string statusString)
        {
            if (statusString == "Possessed")
                return Enums.MediaStatus.Possessed;
            return Enums.MediaStatus.Desired;
        }


        private void bookSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = getRadioButtonInGroupBox(bookStatusRadioGroupBox);
            Enums.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(bookSearchCriteriaRadioGroupBox);

            string searchQuery = bookSearchTextBox.Text;

            List<Book> searchResults = mysqlHelper.searchBook(mediaStatusEnum, Enums.MediaTypeNames.Book, searchCriteria, searchQuery);
            bookResultPanel.Controls.Clear();
            testForm.TopLevel = false;
            testForm.Dock = DockStyle.Fill;
            bookResultPanel.Controls.Add(testForm);
            testForm.Show();
            testForm.loadNewInfo(searchResults);
        }

        private void movieSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = getRadioButtonInGroupBox(movieStatusRadioGroupBox);
            Enums.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(movieSearchCriteriaRadioGroupBox);

            string searchQuery = movieSearchTextBox.Text;

            List<Movie> searchResults = mysqlHelper.searchMovie(mediaStatusEnum, Enums.MediaTypeNames.Movie, searchCriteria, searchQuery);
            movieResultPanel.Controls.Clear();
            movieTestForm.TopLevel = false;
            movieTestForm.Dock = DockStyle.Fill;
            movieResultPanel.Controls.Add(movieTestForm);
            movieTestForm.Show();
            movieTestForm.loadNewInfo(searchResults);
        }

        private void showSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = getRadioButtonInGroupBox(showStatusRadioGroupBox);
            Enums.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(showSearchCriteriaRadioGroupBox);

            string searchQuery = showSearchTextBox.Text;

            List<Show> searchResults = mysqlHelper.searchShow(mediaStatusEnum, Enums.MediaTypeNames.TV_Show, searchCriteria, searchQuery);
            showResultPanel.Controls.Clear();
            showTestForm.TopLevel = false;
            showTestForm.Dock = DockStyle.Fill;
            showResultPanel.Controls.Add(showTestForm);
            showTestForm.Show();
            showTestForm.loadNewInfo(searchResults);
        }

        private void gameSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = getRadioButtonInGroupBox(gameStatusRadioGroupBox);
            Enums.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(gameSearchCriteriaRadioGroupBox);

            string searchQuery = gameSearchTextBox.Text;

            List<Game> searchResults = mysqlHelper.searchGame(mediaStatusEnum, Enums.MediaTypeNames.Video_Game, searchCriteria, searchQuery);
            gameResultPanel.Controls.Clear();
            gameTestForm.TopLevel = false;
            gameTestForm.Dock = DockStyle.Fill;
            gameResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
            gameTestForm.loadNewInfo(searchResults);
        }

        private void bookListAllButton_Click(object sender, EventArgs e)
        {
            List<Book> listAllResult = mysqlHelper.listAllBooks(Enums.MediaStatus.Possessed);
            bookResultPanel.Controls.Clear();
            testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testForm.Dock = DockStyle.Fill;
            testForm.TopLevel = false;
            bookResultPanel.Controls.Add(testForm);
            testForm.Show();
            testForm.loadNewInfo(listAllResult);
        }

        private void gameListAllButton_Click(object sender, EventArgs e)
        {
            List<Game> listAllResult = mysqlHelper.listAllGames(Enums.MediaStatus.Possessed);
            gameResultPanel.Controls.Clear();
            gameTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameTestForm.Dock = DockStyle.Fill;
            gameTestForm.TopLevel = false;
            gameResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
            gameTestForm.loadNewInfo(listAllResult);
        }

        private void movieListAllButton_Click(object sender, EventArgs e)
        {
            List<Movie> listAllResult = mysqlHelper.listAllMovies(Enums.MediaStatus.Possessed);
            movieResultPanel.Controls.Clear();
            movieTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movieTestForm.Dock = DockStyle.Fill;
            movieTestForm.TopLevel = false;
            movieResultPanel.Controls.Add(movieTestForm);
            gameTestForm.Show();
            movieTestForm.loadNewInfo(listAllResult);
        }

        private void showListAllButton_Click(object sender, EventArgs e)
        {
            List<Show> listAllResult = mysqlHelper.listAllShows(Enums.MediaStatus.Possessed);
            showTestForm.loadNewInfo(listAllResult);
            showResultPanel.Controls.Clear();
            showTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            showTestForm.Dock = DockStyle.Fill;
            showTestForm.TopLevel = false;
            showResultPanel.Controls.Add(showTestForm);
            showTestForm.Show();
            showTestForm.loadNewInfo(listAllResult);
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
                bookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                bookResultPanel.Controls.Add(testForm);
                testForm.Show();
            }

            else if (actionDropDownBox.Text == "Move to \"Desired\" media" && dataBaseTabs.SelectedTab.Text == "Possessed Media")
            {
                foreach (DataGridViewRow row in checkedValues)
                {
                    //change this value in database
                    int bookID = (int)row.Cells["book_id"].Value;
                    Console.WriteLine(bookID);
                    mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Book, bookID, "Desired Media");
                    //delete this value in current datasource
                }
                testForm.deleteFromDataSource(checkedValues);
                bookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                bookResultPanel.Controls.Add(testForm);
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
                    mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Book, bookID, "Possessed Media");
                    //delete this value in current datasource
                }
                testForm.deleteFromDataSource(checkedValues);
                bookResultPanel.Controls.Clear();
                testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                testForm.Dock = DockStyle.Fill;
                testForm.TopLevel = false;
                bookResultPanel.Controls.Add(testForm);
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
                newShowForm newShow = new newShowForm();
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


    }
}
