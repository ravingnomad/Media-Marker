using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Types
{
    public class Game
    {
        public int video_game_id { get; set; }
        public string title { get; set; }
        public string developer { get; set; }

        private string _genres;
        private string _platforms;
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
        public string platforms
        {
            get
            {
                return _platforms;
            }

            set
            {
                StringBuilder sb = new StringBuilder(value);
                sb.Replace(',', '\n');
                _platforms = sb.ToString();
            }
        }

    }
}
