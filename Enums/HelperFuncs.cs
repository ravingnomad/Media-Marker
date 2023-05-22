using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperLibrary
{
    public static class HelperFuncs
    {
        /*Referenced code here: https://stackoverflow.com/questions/1797907/which-radio-button-in-the-group-is-checked*/

        public static string getRadioButtonInGroupBox(GroupBox groupBox)
        {
            string returnString = "";
            try
            {
                returnString = groupBox.Controls.OfType<RadioButton>().FirstOrDefault(radio => radio.Checked).Text;
            }

            catch (NullReferenceException e)
            {
            }

            return returnString;
        }

        public static HelperLibrary.MediaTypeNames getMediaTypeEnum(string mediaTypeString)
        {
            if (mediaTypeString == "Books")
                return HelperLibrary.MediaTypeNames.Book;
            else if (mediaTypeString == "Movies")
                return HelperLibrary.MediaTypeNames.Movie;
            else if (mediaTypeString == "Shows")
                return HelperLibrary.MediaTypeNames.TV_Show;
            return HelperLibrary.MediaTypeNames.Video_Game;
        }
    }
}
