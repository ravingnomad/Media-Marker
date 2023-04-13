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
        public bookEditForm(Book selectedBook)
        {
            InitializeComponent();
            bookEditTitleTextBox.Text = selectedBook.title;
            bookEditAuthorTextBox.Text = selectedBook.author;
            List<string> temp = selectedBook.genres.Split('\n').ToList();

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
    }
}
