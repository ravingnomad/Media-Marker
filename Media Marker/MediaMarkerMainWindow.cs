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

            searchResultPanel.Controls.Clear();
            testForm = new bookSearchResultForm();
            testForm.TopLevel = false;
            testForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(testForm);

            searchResultPanel.Controls.Clear();
            gameTestForm = new gameSearchResultForm();
            gameTestForm.TopLevel = false;
            gameTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(gameTestForm);

            searchResultPanel.Controls.Clear();
            movieTestForm = new movieSearchResultForm();
            movieTestForm.TopLevel = false;
            movieTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(movieTestForm);

            searchResultPanel.Controls.Clear();
            showTestForm = new showSearchResultForm();
            showTestForm.TopLevel = false;
            showTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(showTestForm);

            testForm.Show();
            movieTestForm.Show();
            showTestForm.Show();
            gameTestForm.Show();
        }

        private void MediaMarkerMainWindow_Load(object sender, EventArgs e)
        {
            /*
            searchResultPanel.Controls.Clear();
            bookSearchResultForm possessedBookResults = new bookSearchResultForm();
            possessedBookResults.TopLevel = false;
            possessedBookResults.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(possessedBookResults);
            possessedBookResults.Show();

            searchResultPanel.Controls.Clear();
            gameSearchResultForm gameResults = new gameSearchResultForm();
            gameResults.TopLevel = false;
            gameResults.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(gameResults);
            gameResults.Show();

            searchResultPanel.Controls.Clear();
            movieSearchResultForm movieResults = new movieSearchResultForm();
            movieResults.TopLevel = false;
            movieResults.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(movieResults);
            movieResults.Show();

            searchResultPanel.Controls.Clear();
            showSearchResultForm showResults = new showSearchResultForm();
            showResults.TopLevel = false;
            showResults.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(showResults);
            showResults.Show();*/
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
            searchResultPanel.Controls.Clear();
            testForm.TopLevel = false;
            testForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(testForm);
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
            searchResultPanel.Controls.Clear();
            movieTestForm.TopLevel = false;
            movieTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(movieTestForm);
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
            searchResultPanel.Controls.Clear();
            showTestForm.TopLevel = false;
            showTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(showTestForm);
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
            searchResultPanel.Controls.Clear();
            gameTestForm.TopLevel = false;
            gameTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
            gameTestForm.loadNewInfo(searchResults);
        }

        private void bookListAllButton_Click(object sender, EventArgs e)
        {
            Enums.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(bookStatusRadioGroupBox));
            List<Book> listAllResult = mysqlHelper.listAllBooks(mediaStatus);
            searchResultPanel.Controls.Clear();
            testForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            testForm.Dock = DockStyle.Fill;
            testForm.TopLevel = false;
            searchResultPanel.Controls.Add(testForm);
            testForm.Show();
            testForm.loadNewInfo(listAllResult);
        }

        private void gameListAllButton_Click(object sender, EventArgs e)
        {
            Enums.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(gameStatusRadioGroupBox));
            List<Game> listAllResult = mysqlHelper.listAllGames(mediaStatus);
            searchResultPanel.Controls.Clear();
            gameTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gameTestForm.Dock = DockStyle.Fill;
            gameTestForm.TopLevel = false;
            searchResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
            gameTestForm.loadNewInfo(listAllResult);
        }

        private void movieListAllButton_Click(object sender, EventArgs e)
        {
            Enums.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(movieStatusRadioGroupBox));
            List<Movie> listAllResult = mysqlHelper.listAllMovies(mediaStatus);
            searchResultPanel.Controls.Clear();
            movieTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            movieTestForm.Dock = DockStyle.Fill;
            movieTestForm.TopLevel = false;
            searchResultPanel.Controls.Add(movieTestForm);
            gameTestForm.Show();
            movieTestForm.loadNewInfo(listAllResult);
        }

        private void showListAllButton_Click(object sender, EventArgs e)
        {
            Enums.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(showStatusRadioGroupBox));
            List<Show> listAllResult = mysqlHelper.listAllShows(mediaStatus);
            showTestForm.loadNewInfo(listAllResult);
            searchResultPanel.Controls.Clear();
            showTestForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            showTestForm.Dock = DockStyle.Fill;
            showTestForm.TopLevel = false;
            searchResultPanel.Controls.Add(showTestForm);
            showTestForm.Show();
            showTestForm.loadNewInfo(listAllResult);
        }


        //referenced code https://stackoverflow.com/questions/1237829/datagridview-checkbox-column-value-and-functionality
        private void confirmActionButton_Click(object sender, EventArgs e)
        {
            Form searchResultsForm = searchResultPanel.Controls.OfType<Form>().ToList()[0];
            DataGridView activeDataGrid = searchResultsForm.Controls.OfType<DataGridView>().ToList()[0];
            List<DataGridViewRow> checkedValues = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in activeDataGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value) == true)
                {
                    checkedValues.Add(row);
                }
            }

            if (actionDropDownBox.Text == "Delete")
            {

                List<int> chosenMediaPieces = new List<int>();
                string mediaType = mediaTabs.SelectedTab.Text;

                foreach (DataGridViewRow row in checkedValues)
                {
                    if (mediaType == "Books")
                        chosenMediaPieces.Add(Convert.ToInt32(row.Cells["book_id"].Value));
                    else if (mediaType == "Movies")
                        chosenMediaPieces.Add(Convert.ToInt32(row.Cells["movie_id"].Value));
                    else if (mediaType == "Shows")
                        chosenMediaPieces.Add(Convert.ToInt32(row.Cells["tv_show_id"].Value));
                    else if (mediaType == "Games")
                        chosenMediaPieces.Add(Convert.ToInt32(row.Cells["video_game_id"].Value));
                }
                
                mysqlHelper.deleteMediaPieces(chosenMediaPieces, mediaType);
                if (mediaType == "Books")
                    bookListAllButton.PerformClick();
                else if (mediaType == "Movies")
                    movieListAllButton.PerformClick();
                else if (mediaType == "Shows")
                    showListAllButton.PerformClick();
                else if (mediaType == "Games")
                    gameListAllButton.PerformClick();
            }

            else if (actionDropDownBox.Text == "Move to \"Desired\" media")
            {
                List<int> chosenMediaPieces = new List<int>();
                string mediaType = mediaTabs.SelectedTab.Text;
                foreach (DataGridViewRow row in checkedValues)
                {
                    if (mediaType == "Books")
                    {
                        int bookID = Convert.ToInt32(row.Cells["book_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Book, bookID, Enums.MediaStatus.Desired);
                        
                    }
                    else if (mediaType == "Movies")
                    {
                        int movieID = Convert.ToInt32(row.Cells["movie_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Movie, movieID, Enums.MediaStatus.Desired);
                    }
                    else if (mediaType == "Shows")
                    {
                        int showID = Convert.ToInt32(row.Cells["tv_show_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.TV_Show, showID, Enums.MediaStatus.Desired);
                    }
                    else if (mediaType == "Games")
                    {
                        int gameID = Convert.ToInt32(row.Cells["video_game_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Video_Game, gameID, Enums.MediaStatus.Desired);
                    }
                }

                if (mediaType == "Books")
                    bookListAllButton.PerformClick();
                else if (mediaType == "Movies")
                    movieListAllButton.PerformClick();
                else if (mediaType == "Shows")
                    showListAllButton.PerformClick();
                else if (mediaType == "Games")
                    gameListAllButton.PerformClick();
            }

            else if (actionDropDownBox.Text == "Move to \"Possessed\" media")
            {
                List<int> chosenMediaPieces = new List<int>();
                string mediaType = mediaTabs.SelectedTab.Text;
                foreach (DataGridViewRow row in checkedValues)
                {
                    if (mediaType == "Books")
                    {
                        int bookID = Convert.ToInt32(row.Cells["book_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Book, bookID, Enums.MediaStatus.Possessed);
                    }
                    else if (mediaType == "Movies")
                    {
                        int movieID = Convert.ToInt32(row.Cells["movie_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Movie, movieID, Enums.MediaStatus.Possessed);
                    }
                    else if (mediaType == "Shows")
                    {
                        int showID = Convert.ToInt32(row.Cells["tv_show_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.TV_Show, showID, Enums.MediaStatus.Possessed);
                    }
                    else if (mediaType == "Games")
                    {
                        int gameID = Convert.ToInt32(row.Cells["video_game_id"].Value);
                        mysqlHelper.changeMediaStatus(Enums.MediaTypeNames.Video_Game, gameID, Enums.MediaStatus.Possessed);
                    }
                }

                if (mediaType == "Books")
                    bookListAllButton.PerformClick();
                else if (mediaType == "Movies")
                    movieListAllButton.PerformClick();
                else if (mediaType == "Shows")
                    showListAllButton.PerformClick();
                else if (mediaType == "Games")
                    gameListAllButton.PerformClick();
            }

            //to prevent user from being able to open multiple forms, look into making these forms a 'singleton'
            //https://stackoverflow.com/questions/2018272/preventing-multiple-instance-of-one-form-from-displaying
            //above reference might help

            else if (actionDropDownBox.Text == "Edit")
            {
                if (checkedValues.Count != 1)
                {
                    MessageBox.Show("Only one media piece can be selected for editing", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("ERROR: Must select one media piece to edit");
                }

                else
                {
                    DataGridViewRow selectedPiece = checkedValues[0];
                    if (activeDataGrid.Name == "bookDataGridView")
                    {
                        
                        //call mysql function to get book(or other media info) and use that to pass into the edit form
                        Book selectedBook = mysqlHelper.getBook((int)selectedPiece.Cells["book_id"].Value);
                        //Console.WriteLine(selectedBook.fullString);
                        bookEditForm editForm = new bookEditForm(selectedBook);
                        editForm.ShowDialog();
                    }

                    else if (activeDataGrid.Name == "movieDataGridView")
                    {
                        Movie selectedMovie = mysqlHelper.getMovie((int)selectedPiece.Cells["movie_id"].Value);
                        movieEditForm editForm = new movieEditForm(selectedMovie);
                        editForm.ShowDialog();
                    }

                    else if (activeDataGrid.Name == "showDataGridView")
                    {
                        Show selectedShow = mysqlHelper.getShow((int)selectedPiece.Cells["tv_show_id"].Value);
                        showEditForm editForm = new showEditForm(selectedShow);
                        editForm.ShowDialog();
                    }

                    else if (activeDataGrid.Name == "gameDataGridView")
                    {
                        Game selectedGame = mysqlHelper.getGame((int)selectedPiece.Cells["video_game_id"].Value);
                        gameEditForm editForm = new gameEditForm(selectedGame);
                        editForm.ShowDialog();
                    }
                }
            }
            actionDropDownBox.SelectedIndex = -1;
        }





        
        private void newBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newBookRadioButton.Checked)
            {
                newBookForm newBook = new newBookForm();
                newBook.TopLevel = false;
                newMediaEntryPanel.Controls.Clear();
                newMediaEntryPanel.Controls.Add(newBook);
                newBook.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newBook.Dock = DockStyle.Fill;
                newBook.Show();
            }
        }

        private void newMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newMovieRadioButton.Checked)
            {
                newMovieForm newMovie = new newMovieForm();
                newMediaEntryPanel.Controls.Clear();
                newMovie.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newMovie.Dock = DockStyle.Fill;
                newMovie.TopLevel = false;
                newMediaEntryPanel.Controls.Add(newMovie);
                newMovie.Show();
            }
        }

        private void newShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newShowRadioButton.Checked)
            {
                newShowForm newShow = new newShowForm();
                newMediaEntryPanel.Controls.Clear();
                newShow.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newShow.Dock = DockStyle.Fill;
                newShow.TopLevel = false;
                newMediaEntryPanel.Controls.Add(newShow);
                newShow.Show();
            }
        }

        private void newGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newGameRadioButton.Checked)
            {
                newGameForm newGame = new newGameForm();
                newMediaEntryPanel.Controls.Clear();
                newGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newGame.Dock = DockStyle.Fill;
                newGame.TopLevel = false;
                newMediaEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }
    }
}
