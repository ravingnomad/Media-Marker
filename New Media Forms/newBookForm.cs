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
using HelperLibrary;

namespace New_Media_Forms
{
    public partial class NewBookForm : Form
    {
        public NewBookForm()
        {
            InitializeComponent();
        }

        private void addNewBookButton_Click(object sender, EventArgs e)
        {
            string bookTitle = newBookTitleTextBox.Text;
            string authorName = newBookAuthorTextBox.Text;
            string newBookStatusString = getRadioButtonInGroupBox(newBookStatusGroupBox);
            HelperLibrary.MediaStatus newBookStatusEnum = (newBookStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;

            var newBookGenres = bookGenreListBox.CheckedItems;

            List<string> newBookGenresList = new List<string>();
            foreach (string genre in newBookGenres)
            {
                newBookGenresList.Add(genre);
            }
            mysqlHelper.addNewBook(bookTitle, authorName, newBookGenresList, newBookStatusEnum);
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
