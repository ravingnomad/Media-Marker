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

        public static HelperLibrary.MediaStatus getMediaStatusEnum(string statusString)
        {
            if (statusString == "Possessed")
                return HelperLibrary.MediaStatus.Possessed;
            return HelperLibrary.MediaStatus.Desired;
        }

        public static bool checkListBoxChanged(CheckedListBox currentCheckList, HashSet<string> original)
        {
            //temporarily stores the genres that are checked in the check list box
            List<string> temp = new List<string>();

            for (int index = 0; index < currentCheckList.Items.Count; index++)
            {
                if (currentCheckList.GetItemChecked(index) == true)
                    temp.Add(((string)currentCheckList.Items[index]).ToLower());
            }
            //use hash set to see if the original set of genres matches this new set of genres
            HashSet<string> placeHolder = new HashSet<string>(temp);
            return placeHolder.SetEquals(original) == false;
        }
    }
}
