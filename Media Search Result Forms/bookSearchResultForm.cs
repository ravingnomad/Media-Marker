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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bookSearchResultForm_Load(object sender, EventArgs e)
        {
            ///method of creating and adding a column of buttons to the DataGridView came from 
            ///http://csharp.net-informations.com/datagridview/csharp-datagridview-button.htm
            
            bookDataGridView.DataSource = dataSource;
            //DataGridViewCheckBoxColumn buttonCol = new DataGridViewCheckBoxColumn();
            //bookDataGridView.Columns.Add(buttonCol);
            //buttonCol.Name = "buttonSelectColumn";
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

        public void deleteFromDataSource(List<DataGridViewRow> toRemove)
        {
            List<Book> originalData = new List<Book>((List<Book>)bookDataGridView.DataSource);
            foreach (DataGridViewRow selected in toRemove)
            {
                int toRemoveID = (int)selected.Cells["book_id"].Value;
                var itemToRemove = originalData.SingleOrDefault(x => x.book_id == toRemoveID);
                if (itemToRemove != null)
                {
                    originalData.Remove(itemToRemove);
                }
            }
            bookDataGridView.DataSource = originalData;
            Console.WriteLine("Refreshed!");
        }
    }
}
