using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;
using Blueberry.WPF.UserControls;

namespace Blueberry.WPF.Pages.Customers
{
    public class CustomersPageVM : INotifyPropertyChanged
    {
        private UserControl _rightSide;
        public UserControl RightSide
        {
            get => _rightSide;
            set
            {
                _rightSide = value;
                OnPropertyChanged();
            }
        }

        private NewCustomerUserControl _newCustomerUserControl;
        private CustomerList _customerList;
        private ICommand _addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(o => true,
                        o => RightSide = _newCustomerUserControl);   
                }
                return _addCommand;
            }
        }

        public CustomersPageVM()
        {
            RightSide = _customerList;
            var newCustomerVm = new NewCustomerVM();
            newCustomerVm.Done += () => { RightSide = _customerList;};
            _newCustomerUserControl = new NewCustomerUserControl(newCustomerVm);
            _customerList = new CustomerList();
        }
        
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}