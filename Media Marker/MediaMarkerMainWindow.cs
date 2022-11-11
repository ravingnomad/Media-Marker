using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Marker
{
    public partial class MediaMarkerMainWindow : Form
    {
        public MediaMarkerMainWindow()
        {
            InitializeComponent();
        }

        private void newDesiredBookRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredBookRadioButton.Checked)
            {
                Console.WriteLine("Dynamic layout for new desired book entry goes here");
            }
        }

        private void newDesiredMovieRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredMovieRadioButton.Checked)
            {
                Console.WriteLine("Dynamic layout for new desired movie entry goes here");
            }
        }

        private void addNewDesiredEntryTabPage_Click(object sender, EventArgs e)
        {
        }

        private void newDesiredShowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredShowRadioButton.Checked)
            {
                Console.WriteLine("Dynamic layout for new desired show entry goes here");
            }
        }

        private void newDesiredGameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (newDesiredGameRadioButton.Checked)
            {
                Console.WriteLine("Dynamic layout for new desired game entry goes here");
            }
        }
    }
}
