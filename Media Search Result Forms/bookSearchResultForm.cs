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
    public partial class BookSearchResultForm : Form
    {
        private List<Book> dataSource = new List<Book>();
        public BookSearchResultForm()
        {
            InitializeComponent();
        }

        public void loadSearchResults(List<Book> results)
        {
            bookDataGridView.DataSource = results;
            if (bookDataGridView.Columns.Contains("Select") == false)
            {
                DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = "Select";
                bookDataGridView.Columns.Add(buttonCol);
            }
            bookDataGridView.Columns["title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bookDataGridView.Columns["author"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void bookSearchResultForm_Load(object sender, EventArgs e)
        {
            ///method of creating and adding a column of buttons to the DataGridView came from 
            ///http://csharp.net-informations.com/datagridview/csharp-datagridview-button.htm
            
            bookDataGridView.DataSource = dataSource;
        }

        public void loadNewInfo(List<Book> newData)
        {
            bookDataGridView.DataSource = newData;
            if (bookDataGridView.Columns.Contains("Select") == false)
            {
                DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
                buttonCol.Name = "Select";
                bookDataGridView.Columns.Add(buttonCol);
            }
        }
    }
}
