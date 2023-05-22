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
        BookSearchResultForm bookSearchForm;
        MovieSearchResultForm movieSearchForm;
        ShowSearchResultForm showSearchForm;
        GameSearchResultForm gameSearchForm;

        public MediaMarkerMainWindow()
        {
            InitializeComponent();

            bookSearchForm = new BookSearchResultForm();
            loadForm(bookSearchForm, searchResultPanel);

            gameSearchForm = new GameSearchResultForm();
            loadForm(gameSearchForm, searchResultPanel);

            movieSearchForm = new MovieSearchResultForm();
            loadForm(movieSearchForm, searchResultPanel);

            showSearchForm = new ShowSearchResultForm();
            loadForm(showSearchForm, searchResultPanel);
        }





        private void bookSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = HelperFuncs.getRadioButtonInGroupBox(bookStatusRadioGroupBox);
            HelperLibrary.MediaStatus mediaStatusEnum = HelperLibrary.HelperFuncs.getMediaStatusEnum(mediaStatusString);
            string searchCriteria = HelperFuncs.getRadioButtonInGroupBox(bookSearchCriteriaRadioGroupBox);
            string searchQuery = bookSearchTextBox.Text;

            List<Book> searchResults = mysqlHelper.searchBook(mediaStatusEnum, HelperLibrary.MediaTypeNames.Book, searchCriteria, searchQuery);
            bookSearchForm.loadNewInfo(searchResults);
            loadForm(bookSearchForm, searchResultPanel); 
        }

        private void movieSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = HelperFuncs.getRadioButtonInGroupBox(movieStatusRadioGroupBox);
            HelperLibrary.MediaStatus mediaStatusEnum = HelperLibrary.HelperFuncs.getMediaStatusEnum(mediaStatusString);
            string searchCriteria = HelperFuncs.getRadioButtonInGroupBox(movieSearchCriteriaRadioGroupBox);
            string searchQuery = movieSearchTextBox.Text;

            List<Movie> searchResults = mysqlHelper.searchMovie(mediaStatusEnum, HelperLibrary.MediaTypeNames.Movie, searchCriteria, searchQuery);
            movieSearchForm.loadNewInfo(searchResults);
            loadForm(movieSearchForm, searchResultPanel);

        }

        private void showSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = HelperFuncs.getRadioButtonInGroupBox(showStatusRadioGroupBox);
            HelperLibrary.MediaStatus mediaStatusEnum = HelperLibrary.HelperFuncs.getMediaStatusEnum(mediaStatusString);
            string searchCriteria = HelperFuncs.getRadioButtonInGroupBox(showSearchCriteriaRadioGroupBox);
            string searchQuery = showSearchTextBox.Text;

            List<Show> searchResults = mysqlHelper.searchShow(mediaStatusEnum, HelperLibrary.MediaTypeNames.TV_Show, searchCriteria, searchQuery);
            showSearchForm.loadNewInfo(searchResults);
            loadForm(showSearchForm, searchResultPanel);

        }

        private void gameSearchButton_Click(object sender, EventArgs e)
        {
            string mediaStatusString = HelperFuncs.getRadioButtonInGroupBox(gameStatusRadioGroupBox);
            HelperLibrary.MediaStatus mediaStatusEnum = HelperLibrary.HelperFuncs.getMediaStatusEnum(mediaStatusString);
            string searchCriteria = HelperFuncs.getRadioButtonInGroupBox(gameSearchCriteriaRadioGroupBox);
            string searchQuery = gameSearchTextBox.Text;

            List<Game> searchResults = mysqlHelper.searchGame(mediaStatusEnum, HelperLibrary.MediaTypeNames.Video_Game, searchCriteria, searchQuery);
            gameSearchForm.loadNewInfo(searchResults);
            loadForm(gameSearchForm, searchResultPanel);

        }

        private void bookListAllButton_Click(object sender, EventArgs e)
        {
            HelperLibrary.MediaStatus mediaStatus = HelperLibrary.HelperFuncs.getMediaStatusEnum(HelperFuncs.getRadioButtonInGroupBox(bookStatusRadioGroupBox));
            List<Book> listAllResult = mysqlHelper.listAllBooks(mediaStatus);
            bookSearchForm.loadNewInfo(listAllResult);
            loadForm(bookSearchForm, searchResultPanel); 
        }

        private void gameListAllButton_Click(object sender, EventArgs e)
        {
            HelperLibrary.MediaStatus mediaStatus = HelperLibrary.HelperFuncs.getMediaStatusEnum(HelperFuncs.getRadioButtonInGroupBox(gameStatusRadioGroupBox));
            List<Game> listAllResult = mysqlHelper.listAllGames(mediaStatus);
            gameSearchForm.loadNewInfo(listAllResult);
            loadForm(gameSearchForm, searchResultPanel);
        }

        private void movieListAllButton_Click(object sender, EventArgs e)
        {
            HelperLibrary.MediaStatus mediaStatus = HelperLibrary.HelperFuncs.getMediaStatusEnum(HelperFuncs.getRadioButtonInGroupBox(movieStatusRadioGroupBox));
            List<Movie> listAllResult = mysqlHelper.listAllMovies(mediaStatus);
            movieSearchForm.loadNewInfo(listAllResult);
            loadForm(movieSearchForm, searchResultPanel);
        }

        private void showListAllButton_Click(object sender, EventArgs e)
        {
            HelperLibrary.MediaStatus mediaStatus = HelperLibrary.HelperFuncs.getMediaStatusEnum(HelperFuncs.getRadioButtonInGroupBox(showStatusRadioGroupBox));
            List<Show> listAllResult = mysqlHelper.listAllShows(mediaStatus);
            showSearchForm.loadNewInfo(listAllResult);
            loadForm(showSearchForm, searchResultPanel);
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
                default:
                    MessageBox.Show("No action selected from dropdown", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                loadNewMediaForm(HelperLibrary.MediaTypeNames.Book);
            }
        }

        private void newMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newMovieRadioButton.Checked)
            {
                loadNewMediaForm(HelperLibrary.MediaTypeNames.Movie);
            }
        }

        private void newShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newShowRadioButton.Checked)
            {
                loadNewMediaForm(HelperLibrary.MediaTypeNames.TV_Show);
            }
        }

        private void newGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newGameRadioButton.Checked)
            {
                loadNewMediaForm(HelperLibrary.MediaTypeNames.Video_Game);
            }
        }


        private void loadNewMediaForm(HelperLibrary.MediaTypeNames mediaType)
        {
            switch(mediaType)
            {
                case HelperLibrary.MediaTypeNames.Book:
                    NewBookForm bookForm = new NewBookForm();
                    loadForm(bookForm, newMediaEntryPanel);
                    break;
                case HelperLibrary.MediaTypeNames.Movie:
                    NewMovieForm movieForm = new NewMovieForm();
                    loadForm(movieForm, newMediaEntryPanel);
                    break;
                case HelperLibrary.MediaTypeNames.TV_Show:
                    NewShowForm showForm = new NewShowForm();
                    loadForm(showForm, newMediaEntryPanel);
                    break;
                case HelperLibrary.MediaTypeNames.Video_Game:
                    NewGameForm gameForm = new NewGameForm();
                    loadForm(gameForm, newMediaEntryPanel);
                    break;
            }
        }



        /// <summary>
        /// Loads a user-given form into the user-given panel
        /// </summary>
        /// <param name="formToLoad"></param>
        /// <param name="basePanel"></param>
        private void loadForm(Form formToLoad, Panel basePanel)
        {
            basePanel.Controls.Clear();
            formToLoad.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            formToLoad.Dock = DockStyle.Fill;
            formToLoad.TopLevel = false;
            basePanel.Controls.Add(formToLoad);
            formToLoad.Show();
        }



        private void bookClearButon_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
            bookSearchTextBox.Clear();
        }

        private void movieClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
            movieSearchTextBox.Clear();
        }

        private void showClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
            showSearchTextBox.Clear();
        }

        private void gameClearButton_Click(object sender, EventArgs e)
        {
            searchResultPanel.Controls.Clear();
            gameSearchTextBox.Clear();
        }



        /// <summary>
        /// Refreshes the current page by clicking the 'List All' button
        /// </summary>
        /// <param name="mediaType"></param>
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
