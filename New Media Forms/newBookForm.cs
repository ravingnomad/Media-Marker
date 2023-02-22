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
        private string originTab;
        public newBookForm(string origin)
        {
            originTab = origin;
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            /*This method works; simple have a parameter in the constructor of each new form that takes a string describing
             which tab (possessed or desired) this form was opened from*/
            Console.WriteLine(originTab);

            string bookTitle = newBookTitleTextBox.Text;
            string authorName = newBookAuthorTextBox.Text;
            var newBookGenres = bookGenreListBox.CheckedItems;

            List<string> newBookGenresList = new List<string>();
            foreach (string genre in newBookGenres)
            {
                newBookGenresList.Add(genre);
            }
            mysqlHelper.addNewBook(bookTitle, authorName, newBookGenresList, originTab);
        }
    }
}
