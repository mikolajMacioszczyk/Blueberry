using System.Windows.Controls;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(ViewModel Model)
        {
            InitializeComponent();
            DataContext = new HomePageVM(Model);
        }
    }
}
