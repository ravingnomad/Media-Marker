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
    public partial class NewMovieForm : Form
    {
        public NewMovieForm()
        {
            InitializeComponent();
        }

        private void addNewMovieButton_Click(object sender, EventArgs e)
        {
            string movieTitle = newMovieTitleTextBox.Text;
            string directorName = newMovieDirectorTextBox.Text;
            var newMovieGenres = newMovieGenreListBox.CheckedItems;
            string newMovieStatusString = getRadioButtonInGroupBox(newMovieStatusGroupBox);
            HelperLibrary.MediaStatus newMovieStatusEnum = (newMovieStatusString == "Possessed") ? HelperLibrary.MediaStatus.Possessed : HelperLibrary.MediaStatus.Desired;

            List<string> newMovieGenresList = new List<string>();
            foreach (string genre in newMovieGenres)
            {
                newMovieGenresList.Add(genre);
            }
            mysqlHelper.addNewMovie(movieTitle, directorName, newMovieGenresList, newMovieStatusEnum);
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
