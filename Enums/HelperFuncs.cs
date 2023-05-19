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
    }
}
