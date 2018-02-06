using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FourthDay.HelpClasses
{
    class Messages
    {
        static public void OK(string str)
        {
            MessageBox.Show(str,"Perfect",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        static public void Error(string str)
        {
            MessageBox.Show(str, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
