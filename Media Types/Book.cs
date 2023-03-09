using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Types
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string genres { get; set; }

        public string fullString { get { return $" { title }  : { author } GENRES: {genres}"; } }
    }
}
