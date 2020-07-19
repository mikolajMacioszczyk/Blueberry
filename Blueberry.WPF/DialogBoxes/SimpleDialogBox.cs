using System;
using System.Windows;

namespace Blueberry.WPF.DialogBoxes
{
    public class SimpleDialogBox : DialogBox
    {
        public SimpleDialogBox()
        {
            execute = o =>
            {
                MessageBox.Show((string) o, Caption);
            };
        }
    }
}