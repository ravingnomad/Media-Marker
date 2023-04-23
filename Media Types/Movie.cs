using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Media_Types
{
    public class Movie
    {
        public int movie_id { get; set; }
        public string title { get; set; }
        public string director { get; set; }
        public string genres { get; set; }

        //public string fullString { get { return $" { title }  : { director } GENRES: {genres}"; } }
    }
}
