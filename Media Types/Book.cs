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
        public List<string> genre { get; set; }
        public int pages { get; set; }

    }
}
