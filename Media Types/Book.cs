using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Types
{
    public class Book
    {
        public int book_id { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        private string _genres;
        public string genres { 
            get
            {
                return _genres;
            }

            set
            {
                StringBuilder sb = new StringBuilder(value);
                sb.Replace(',', '\n');
                _genres = sb.ToString();
            }
        }

        public string fullString { get { return $" {book_id}   { title }  : { author } GENRES: {_genres}"; } }
    }
}
