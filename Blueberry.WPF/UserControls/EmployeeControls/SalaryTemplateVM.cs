using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Blueberry.DLL;
using Blueberry.DLL.Models;
using Blueberry.WPF.Annotations;
using Blueberry.WPF.Commands;

namespace Blueberry.WPF.UserControls.EmployeeControls
{
    public class SalaryTemplateVM : INotifyPropertyChanged
    {
        #region Properties
        public Employee Employee {get; private set; }
        private bool _isBottomContentVisible;
        public bool IsBottomContentVisible
        {
            get { return _isBottomContentVisible; }
            set
            {
                _isBottomContentVisible = value;
                OnPropertyChanged();
            }
        }
        private float _toPay;
        public float ToPay
        {
            get { return _toPay; }
            set
            {
                _toPay = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand _payAllCommand;
        public ICommand PayAllCommand
        {
            get
            {
                if (_payAllCommand == null)
                {
                    _payAllCommand = new RelayCommand(p => Employee.UnPaided > 0.1, p =>
                    {
                        Pay(Employee.UnPaided);
                    });
                }
                return _payAllCommand;
            }
        }
        private ICommand _payPartCommand;
        public ICommand PayPartCommand
        {
            get
            {
                if (_payPartCommand == null)
                {
                    _payPartCommand = new RelayCommand(p => Employee.UnPaided > 0.1,
                        p => PayPart());
                }
                return _payPartCommand;
            }
        }
        private ICommand _discardCommand;
        public ICommand DiscardCommand
        {
            get
            {
                if (_discardCommand == null)
                {
                    _discardCommand = new RelayCommand(p => true,
                        p => { IsBottomContentVisible = false;});
                }
                return _discardCommand;
            }
        }
        private ICommand _acceptCommand;
        public ICommand AcceptCommand
        {
            get
            {
                if (_acceptCommand == null)
                {
                    _acceptCommand = new RelayCommand(p => true, p =>
                    {
                        Pay(ToPay);
                    });
                }
                return _acceptCommand;
            }
        }
        #endregion

        public SalaryTemplateVM(Employee employee)
        {
            Employee = employee;
        }
        
        private void Pay(float pay)
        {
            DBConnector.GetInstance().ModifyEmployeeAsync(Employee, new []{new Modification(Employee.UnPaided, Employee.UnPaided-pay)});
            Employee.UnPaided -= pay;
            CommandManager.InvalidateRequerySuggested();
            IsBottomContentVisible = false;
        }
        
        private void PayPart()
        {
            IsBottomContentVisible = true;
        }
        
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}