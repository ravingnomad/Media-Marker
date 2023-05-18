using System;
using Media_Types;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Search_Result_Forms
{
    public partial class GameSearchResultForm : Form
    {
        private List<Game> dataSource = new List<Game>();
        public GameSearchResultForm()
        {
            InitializeComponent();
        }

        private void gameSearchResultForm_Load_1(object sender, EventArgs e)
        {
            gameDataGridView.DataSource = dataSource;
        }

        public void loadNewInfo(List<Game> newData)
        {
            gameDataGridView.DataSource = newData;
            if (gameDataGridView.Columns.Contains("Select") == false)
            {
                DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = "Select";
                gameDataGridView.Columns.Add(buttonCol);
            }
        }
    }
}
