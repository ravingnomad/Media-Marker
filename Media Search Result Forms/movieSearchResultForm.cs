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
    public partial class movieSearchResultForm : Form
    {
        private List<Movie> dataSource = new List<Movie>();

        public movieSearchResultForm()
        {
            InitializeComponent();
        }

        private void movieSearchResultForm_Load(object sender, EventArgs e)
        {
            movieDataGridView.DataSource = dataSource;
        }

        public void loadNewInfo(List<Movie> newData)
        {
            movieDataGridView.DataSource = newData;
            if (movieDataGridView.Columns.Contains("Select") == false)
            {
                DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = "Select";
                movieDataGridView.Columns.Add(buttonCol);
            }
        }
    }
}
