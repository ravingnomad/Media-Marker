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
            if (hasError() == false)
            {
                string bookTitle = newBookTitleTextBox.Text;
                string authorName = newBookAuthorTextBox.Text;
                string newBookStatusString = HelperFuncs.getRadioButtonInGroupBox(newBookStatusGroupBox);
                HelperLibrary.MediaStatus newBookStatusEnum = (newBookStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;

                var newBookGenres = bookGenreListBox.CheckedItems;
                List<string> newBookGenresList = new List<string>();
                foreach (string genre in newBookGenres)
                {
                    newBookGenresList.Add(genre);
                }
                mysqlHelper.addNewBook(bookTitle, authorName, newBookGenresList, newBookStatusEnum);
                resetForm();
            }
        }

        private bool hasError()
        {
            StringBuilder errorMessage = new StringBuilder();
            if (HelperLibrary.HelperFuncs.textBoxIsEmpty(newBookTitleTextBox, newBookAuthorTextBox))
                errorMessage.Append("'Title' and 'Author' fields must both have a value.\n");

            if (HelperLibrary.HelperFuncs.checkListBoxIsEmpty(bookGenreListBox))
                errorMessage.Append("There must be at least 1 genre selected.\n");

            if (newBookTitleTextBox.Text != "" &&
                mysqlHelper.getMediaPieceTitle(HelperLibrary.MediaTypeNames.Book, newBookTitleTextBox.Text) != "")
                errorMessage.Append("Title must be unique.\n");

            if (HelperLibrary.HelperFuncs.getRadioButtonInGroupBox(newBookStatusGroupBox) == "")
                errorMessage.Append("A 'Status' for this media piece must be selected\n");

            if (errorMessage.Length != 0)
                MessageBox.Show(errorMessage.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);


            return errorMessage.Length != 0;
        }


        private void resetForm()
        {
            newBookTitleTextBox.Clear();
            newBookAuthorTextBox.Clear();
            newBookPossessedRadioButton.Checked = false;
            newBookDesiredRadioButton.Checked = false;
            foreach (int index in bookGenreListBox.CheckedIndices)
            {
                bookGenreListBox.SetItemCheckState(index, CheckState.Unchecked);
            }
        }
    }
}
