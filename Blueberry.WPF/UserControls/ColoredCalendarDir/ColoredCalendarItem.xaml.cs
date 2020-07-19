using System.Windows.Controls;
using Blueberry.WPF.UserControls.ColoredCalendarDir;
using Blueberry.WPF.ViewModels;

namespace Blueberry.WPF.UserControls
{
    public partial class ColoredCalendarItem : UserControl
    {
        private readonly ColoredCalendarVM _model;

        public ColoredCalendarItem(ColoredCalendarVM model)
        {
            _model = model;
            DataContext = model;
            InitializeComponent();
        }
    }
}