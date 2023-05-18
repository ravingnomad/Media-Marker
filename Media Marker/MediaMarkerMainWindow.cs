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
using HelperLibrary;


namespace Media_Marker
{
    public partial class MediaMarkerMainWindow : Form
    {
        BookSearchResultForm testForm;
        MovieSearchResultForm movieTestForm;
        ShowSearchResultForm showTestForm;
        GameSearchResultForm gameTestForm;

        public MediaMarkerMainWindow()
        {
            InitializeComponent();

            searchResultPanel.Controls.Clear();
            testForm = new BookSearchResultForm();
            testForm.TopLevel = false;
            testForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(testForm);

            searchResultPanel.Controls.Clear();
            gameTestForm = new GameSearchResultForm();
            gameTestForm.TopLevel = false;
            gameTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(gameTestForm);

            searchResultPanel.Controls.Clear();
            movieTestForm = new MovieSearchResultForm();
            movieTestForm.TopLevel = false;
            movieTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(movieTestForm);

            searchResultPanel.Controls.Clear();
            showTestForm = new ShowSearchResultForm();
            showTestForm.TopLevel = false;
            showTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(showTestForm);

            testForm.Show();
            movieTestForm.Show();
            showTestForm.Show();
            gameTestForm.Show();
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

        private HelperLibrary.MediaStatus getMediaStatusEnum(string statusString)
        {
            if (statusString == "Possessed")
                return HelperLibrary.MediaStatus.Possessed;
            return HelperLibrary.MediaStatus.Desired;
        }


        private void bookSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = getRadioButtonInGroupBox(bookStatusRadioGroupBox);
            HelperLibrary.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(bookSearchCriteriaRadioGroupBox);

            string searchQuery = bookSearchTextBox.Text;

            List<Book> searchResults = mysqlHelper.searchBook(mediaStatusEnum, HelperLibrary.MediaTypeNames.Book, searchCriteria, searchQuery);
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
            HelperLibrary.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(movieSearchCriteriaRadioGroupBox);

            string searchQuery = movieSearchTextBox.Text;

            List<Movie> searchResults = mysqlHelper.searchMovie(mediaStatusEnum, HelperLibrary.MediaTypeNames.Movie, searchCriteria, searchQuery);
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
            HelperLibrary.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(showSearchCriteriaRadioGroupBox);

            string searchQuery = showSearchTextBox.Text;

            List<Show> searchResults = mysqlHelper.searchShow(mediaStatusEnum, HelperLibrary.MediaTypeNames.TV_Show, searchCriteria, searchQuery);
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
            HelperLibrary.MediaStatus mediaStatusEnum = getMediaStatusEnum(mediaStatusString);

            /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/
            string searchCriteria = getRadioButtonInGroupBox(gameSearchCriteriaRadioGroupBox);

            string searchQuery = gameSearchTextBox.Text;

            List<Game> searchResults = mysqlHelper.searchGame(mediaStatusEnum, HelperLibrary.MediaTypeNames.Video_Game, searchCriteria, searchQuery);
            searchResultPanel.Controls.Clear();
            gameTestForm.TopLevel = false;
            gameTestForm.Dock = DockStyle.Fill;
            searchResultPanel.Controls.Add(gameTestForm);
            gameTestForm.Show();
            gameTestForm.loadNewInfo(searchResults);
        }

        private void bookListAllButton_Click(object sender, EventArgs e)
        {
            HelperLibrary.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(bookStatusRadioGroupBox));
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
            HelperLibrary.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(gameStatusRadioGroupBox));
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
            HelperLibrary.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(movieStatusRadioGroupBox));
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
            HelperLibrary.MediaStatus mediaStatus = getMediaStatusEnum(getRadioButtonInGroupBox(showStatusRadioGroupBox));
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


        private void confirmActionButton_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> selectedRows = getSelectedRows();
            string mediaType = mediaTabs.SelectedTab.Text;
            switch (actionDropDownBox.Text)
            {
                case "Delete":
                    deleteSelectedRows(selectedRows, mediaType);
                    break;
                case "Move to \"Desired\" media":
                    changeStatusSelectedRows(selectedRows, mediaType, HelperLibrary.MediaStatus.Desired);
                    break;
                case "Move to \"Possessed\" media":
                    changeStatusSelectedRows(selectedRows, mediaType, HelperLibrary.MediaStatus.Possessed);
                    break;
                case "Edit":
                    editSelectedRows(selectedRows, mediaType);
                    break;
            }
            refresh(mediaType);
            actionDropDownBox.SelectedIndex = -1;
        }


        /// <summary>
        /// Returns a list of DataGridViewRows in the current DataGridView that has a check mark under the 'Selected' column
        /// referenced code https://stackoverflow.com/questions/1237829/datagridview-checkbox-column-value-and-functionality
        /// </summary>
        /// <returns></returns>
        private List<DataGridViewRow> getSelectedRows()
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
            return checkedValues;
        }


        /// <summary>
        /// Deletes the selected rows in the current DataGridView. Checks current type of tab currently opened (Book, Movie, Show, or Game)
        /// and uses the corresponding string id name to index and locate the numerical id of the selected row. 
        /// Then queries MySql, using that numerical id, for deletion.
        /// </summary>
        /// <param name="checkedValues"></param>
        private void deleteSelectedRows(List<DataGridViewRow> selectedRows, string mediaType)
        {
            List<int> chosenMediaPieces = new List<int>();
            foreach (DataGridViewRow row in selectedRows)
            {
                string mediaID = "";
                switch (mediaType)
                {
                    case "Books":
                        mediaID = "book_id";
                        break;
                    case "Movies":
                        mediaID = "movie_id";
                        break;
                    case "Shows":
                        mediaID = "tv_show_id";
                        break;
                    case "Games":
                        mediaID = "video_game_id";
                        break;
                }
                chosenMediaPieces.Add(Convert.ToInt32(row.Cells[mediaID].Value));
            }
            mysqlHelper.deleteMediaPieces(chosenMediaPieces, mediaType);
        }


        /// <summary>
        /// Change the media status to either 'Possessed' or 'Desired', given the value of 'newStatus'.
        /// </summary>
        /// <param name="selectedRows"></param>
        /// <param name="mediaType"></param>
        private void changeStatusSelectedRows(List<DataGridViewRow> selectedRows, string mediaType, HelperLibrary.MediaStatus newStatus)
        {
            foreach (DataGridViewRow row in selectedRows)
            {
                switch (mediaType)
                {
                    case "Books":
                        int bookID = Convert.ToInt32(row.Cells["book_id"].Value);
                        mysqlHelper.changeMediaStatus(HelperLibrary.MediaTypeNames.Book, bookID, newStatus);
                        break;
                    case "Movies":
                        int movieID = Convert.ToInt32(row.Cells["movie_id"].Value);
                        mysqlHelper.changeMediaStatus(HelperLibrary.MediaTypeNames.Movie, movieID, newStatus);
                        break;
                    case "Shows":
                        int showID = Convert.ToInt32(row.Cells["tv_show_id"].Value);
                        mysqlHelper.changeMediaStatus(HelperLibrary.MediaTypeNames.TV_Show, showID, newStatus);
                        break;
                    case "Games":
                        int gameID = Convert.ToInt32(row.Cells["video_game_id"].Value);
                        mysqlHelper.changeMediaStatus(HelperLibrary.MediaTypeNames.Video_Game, gameID, newStatus);
                        break;
                }
            }
        }


        /// <summary>
        /// Allows user to edit the single row that is selected. Does not allow for more than one row being selected.
        /// </summary>
        /// <param name="selectedRows"></param>
        /// <param name="mediaType"></param>
        private void editSelectedRows(List<DataGridViewRow> selectedRows, string mediaType)
        {
            if (selectedRows.Count != 1)
            {
                MessageBox.Show("Only one media piece can be selected for editing", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                DataGridViewRow selectedPiece = selectedRows[0];
                switch (mediaType)
                {
                    case "Books":
                        Book selectedBook = mysqlHelper.getBook((int)selectedPiece.Cells["book_id"].Value);
                        BookEditForm bookEditForm = new BookEditForm(selectedBook);
                        bookEditForm.ShowDialog();
                        break;
                    case "Movies":
                        Movie selectedMovie = mysqlHelper.getMovie((int)selectedPiece.Cells["movie_id"].Value);
                        MovieEditForm movieEditForm = new MovieEditForm(selectedMovie);
                        movieEditForm.ShowDialog();
                        break;
                    case "Shows":
                        Show selectedShow = mysqlHelper.getShow((int)selectedPiece.Cells["tv_show_id"].Value);
                        ShowEditForm showEditForm = new ShowEditForm(selectedShow);
                        showEditForm.ShowDialog();
                        break;
                    case "Games":
                        Game selectedGame = mysqlHelper.getGame((int)selectedPiece.Cells["video_game_id"].Value);
                        GameEditForm gameEditForm = new GameEditForm(selectedGame);
                        gameEditForm.ShowDialog();
                        break;

                }
            }
        }



        private void newBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newBookRadioButton.Checked)
            {
                NewBookForm newBook = new NewBookForm();
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
                NewMovieForm newMovie = new NewMovieForm();
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
                NewShowForm newShow = new NewShowForm();
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
                NewGameForm newGame = new NewGameForm();
                newMediaEntryPanel.Controls.Clear();
                newGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                newGame.Dock = DockStyle.Fill;
                newGame.TopLevel = false;
                newMediaEntryPanel.Controls.Add(newGame);
                newGame.Show();
            }
        }

        private void bookClearButon_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
        }

        private void movieClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
        }

        private void showClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
        }

        private void gameClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
        }

        private void refresh(string mediaType)
        {
            if (mediaType == "Books")
                bookListAllButton.PerformClick();
            else if (mediaType == "Movies")
                movieListAllButton.PerformClick();
            else if (mediaType == "Shows")
                showListAllButton.PerformClick();
            else if (mediaType == "Games")
                gameListAllButton.PerformClick();
        }
    }
}
