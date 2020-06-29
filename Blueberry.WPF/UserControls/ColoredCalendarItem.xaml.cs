using System.Windows.Controls;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.UserControls
{
    public partial class ColoredCalendarItem : UserControl
    {
        private readonly ColoredCalendarViewModel _model;

        public ColoredCalendarItem(ColoredCalendarViewModel model)
        {
            _model = model;
            DataContext = model;
            InitializeComponent();
        }
    }
}