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

namespace Media_Edit_Forms
{
    public partial class bookEditForm : Form
    {
        //look at genres or game platforms and comb through the check boxes and tick those that its able to match
        //to save the info into database:
        //1.) check to see if any changes were made
        //
        //2.) if changes were made, AND save button clicked, check what changes were made
        //
        //3.) call the appropriate mysql function/stored procedure to change that info; this means creating new stored procedures in mysql
        //to facilitate this
        //
        //4.) overwrite the old info with new; in cases where the info is a list (i.e. genres or game platforms) easiest method will probably
        //be to delete old info (JUST genres/game platforms) and have it store the new info; otherwise will have to comb through database
        //and see if old data exists in new edit, and that sounds more complicated
        //
        //5.) iff changes were made, use the row's media id to pull that same info from the database and populate that row in
        ////main form with the new data; this way data is present on the same page and user will (hopefully) not be lost/confused
        //
        private int bookID;
        private string originalTitle;
        private string originalAuthor;
        private HashSet<string> originalGenres;

        public bookEditForm(Book selectedBook)
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
            mysqlHelper.updateBook(bookID, updatedFields);
        }

        private bool genresChanged()
        {
            //temporarily stores the genres that are check in the check list box
            List<string> temp = new List<string>();

            for (int index = 0; index < bookEditGenreListBox.Items.Count; index++)
            {
                if (bookEditGenreListBox.GetItemChecked(index) == true)
                temp.Add(((string)bookEditGenreListBox.Items[index]).ToLower());
            }
            
            //use hash set to see if the original set of genres matches this new set of genres
            HashSet<string> placeHolder = new HashSet<string> (temp);
            return placeHolder.SetEquals(originalGenres) == false;

        }
    }
}
