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

namespace New_Media_Forms
{
    public partial class newBookForm : Form
    {
        private string newMediaStatus;
        public newBookForm()
        {
            InitializeComponent();
            //newMediaStatus = mediaStatus;
            //Console.WriteLine($"Status is { newMediaStatus }");
        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            string bookTitle = newBookTitleTextBox.Text;
            string authorName = newBookAuthorTextBox.Text;
            var newBookGenres = bookGenreListBox.CheckedItems;

            List<string> newBookGenresList = new List<string>();
            foreach (string genre in newBookGenres)
            {
                newBookGenresList.Add(genre);
            }
            mysqlHelper.addNewBook(bookTitle, authorName, newBookGenresList, newMediaStatus);
        }
    }
}
