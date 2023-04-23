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

namespace Media_Search_Result_Forms
{
    public partial class showSearchResultForm : Form
    {
        private List<Show> dataSource = new List<Show>();

        public showSearchResultForm()
        {
            InitializeComponent();
        }

        private void showSearchResultForm_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = dataSource;
        }

        public void loadNewInfo(List<Show> newData)
        {
            showDataGridView.DataSource = newData;
            if (showDataGridView.Columns.Contains("Select") == false)
            {
                DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = "Select";
                showDataGridView.Columns.Add(buttonCol);
            }
        }
    }
}
