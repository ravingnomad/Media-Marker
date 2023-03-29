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
    public partial class bookSearchResultForm : Form
    {
        private List<Book> dataSource = new List<Book>();
        public bookSearchResultForm()
        {
            //GetExampleBookData();
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
            //bookDataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //bookDataGridView.Columns["genres"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //bookDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //bookDataGridView.Dock = DockStyle.Fill;
            //bookDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //bookDataGridView.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //bookDataGridView.Refresh();
        }

        private void GetExampleBookData()
        {
            dataSource.Add(new Book()
            {
                title = "Hunchback of Notre Dame",
                author = "Victor Hugo",
                //genre = new List<string>() { "Suspense", "Historical Fiction", "Romance", "Comedy" },
                //pages = 590
            });

            dataSource.Add(new Book()
            {
                title = "Of Mice and men",
                author = "John Steinbeck",
                ///genre = new List<string>() { "Suspense", "Tragedy", "Drama", "Comedy" },
                //pages = 120
            });

            dataSource.Add(new Book()
            {
                title = "Dante's Inferno",
                author = "Dante Alighieri",
                //genre = new List<string>() { "Horror", "Poetry" },
                //pages = 170
            });

            dataSource.Add(new Book()
            {
                title = "The Big Sleep",
                author = "Raymond Chandler",
                //genre = new List<string>() { "Suspense", "Mystery", "Comedy" },
                //pages = 320
            });

            dataSource.Add(new Book()
            {
                title = "Lord of the Flies",
                author = "William Golding",
                //genre = new List<string>() { "Suspense", "Action", "Horror", "Comedy" },
                //pages = 200
            });

            dataSource.Add(new Book()
            {
                title = "War and Peace",
                author = "Leo Tolstoy",
                //genre = new List<string>() { "Historical Fiction", "Romance", "Drama" },
                //pages = 1320
            });
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
    }
}
