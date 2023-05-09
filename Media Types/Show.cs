using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Types
{
    public class Show
    {
        public int tv_show_id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public int seasons { get; set; }
        public int episodes { get; set; }

        private string _genres;
        public string genres
        {
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

    }
}
