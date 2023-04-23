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
        public string genres { get; set; }

        //public string fullString { get { return $" {platform_id} : {platform_name}"; } }
    }
}
