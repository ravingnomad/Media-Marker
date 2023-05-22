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
using HelperLibrary;

namespace Media_Edit_Forms
{
    public partial class BookEditForm : Form
    {
        private int bookID;
        private string originalTitle;
        private string originalAuthor;
        private HashSet<string> originalGenres;

        public BookEditForm(Book selectedBook)
        {
            InitializeComponent();
            //used to check if change was made in any of these fields
            bookID = selectedBook.book_id;
            originalTitle = selectedBook.title;
            originalAuthor = selectedBook.author;
            originalGenres = new HashSet<string> (selectedBook.genres.Split('\n').ToList());

            bookEditTitleTextBox.Text = selectedBook.title;
            bookEditAuthorTextBox.Text = selectedBook.author;
            List<string> temp = selectedBook.genres.Split('\n').ToList();

            //checks tickboxes for genres that the book was imported with
            List<int> indicesToCheck = new List<int>();

            foreach (string genre in bookEditGenreListBox.Items)
            {
                if (temp.Contains(genre.ToLower()))
                {
                    int location = bookEditGenreListBox.Items.IndexOf(genre);
                    indicesToCheck.Add(location);
                }
            }

            foreach (int location in indicesToCheck)
            {
                bookEditGenreListBox.SetItemChecked(location, true);
            }
        }

        private void bookEditSaveButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedFields = new Dictionary<string, string>();

            if (bookEditTitleTextBox.Text != originalTitle)
            {
                updatedFields.Add("Title", bookEditTitleTextBox.Text);
            }

            if (bookEditAuthorTextBox.Text != originalAuthor)
            {
                updatedFields.Add("Author", bookEditAuthorTextBox.Text);
            }

            if (genresChanged())
            {
                List<string> genreList = new List<string>();
                foreach (string genre in bookEditGenreListBox.CheckedItems)
                {
                    genreList.Add(genre);
                }
                string newGenresString = String.Join(",", genreList);
                updatedFields.Add("Genre", newGenresString);
            }
            mysqlHelper.updateMediaPiece(HelperLibrary.MediaTypeNames.Book, bookID, updatedFields);
            this.Close();
        }

        private bool genresChanged()
        {
            return HelperLibrary.HelperFuncs.checkListBoxChanged(bookEditGenreListBox, originalGenres);
        }
    }
}
