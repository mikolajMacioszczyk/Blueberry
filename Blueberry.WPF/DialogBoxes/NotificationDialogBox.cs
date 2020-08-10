using System.Windows;

namespace Blueberry.WPF.DialogBoxes
{
    public class NotificationDialogBox : CommandDialogBox
    {
        public NotificationDialogBox()
        {
            execute = o =>
            {
                MessageBox.Show((string) o, Caption,
                    MessageBoxButton.OK, MessageBoxImage.Information);
            };
        }
    }
}