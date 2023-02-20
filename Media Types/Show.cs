using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Types
{
    public class Show
    {
        public int platform_id;
        public string platform_name;

        public string fullString { get { return $" {platform_id} : {platform_name}"; } }
    }
}
