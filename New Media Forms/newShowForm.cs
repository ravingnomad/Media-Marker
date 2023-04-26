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
    public partial class newShowForm : Form
    {
        private string newMediaStatus;
        public newShowForm(string mediaStatus)
        {
            InitializeComponent();
            newMediaStatus = mediaStatus;
            Console.WriteLine($"Status is { newMediaStatus }");
        }

        /// <summary>
        /// This prevents the current form from being moved by the user
        /// Code gotten from https://stackoverflow.com/questions/907830/how-do-you-prevent-a-windows-from-being-moved
        /// </summary>
        /// <param name="message"></param>
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void addNewShowButton_Click(object sender, EventArgs e)
        {
            string showTitle = newShowTitleTextBox.Text;
            string directorName = newShowDirectorTextBox.Text;
            int seasons = 0;
            int episodes = 0;
            if (newShowSeasonTextBox.Text != "")
                seasons = Int32.Parse(newShowSeasonTextBox.Text);
            if (newShowEpisodesTextBox.Text != "")
                episodes = Int32.Parse(newShowEpisodesTextBox.Text);

            var newShowGenres = showGenreListBox.CheckedItems;

            List<string> newShowGenresList = new List<string>();
            foreach (string genre in newShowGenres)
            {
                newShowGenresList.Add(genre);
            }
            mysqlHelper.addNewShow(showTitle, directorName, seasons, episodes, newShowGenresList, newMediaStatus);
        }
    }
}
