using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Blueberry.DLL.Models;
using Blueberry.WPF.Enums;
using Blueberry.WPF.PageEventArgs;

namespace Blueberry.WPF.UserControls
{
    public partial class NewOrderPanel : UserControl
    {
        public event EventHandler<NewOrderEventArgs> OrderAdded; 
        
        private ViewModel _model;
        public NewOrderPanel(ViewModel model)
        {    
            InitializeComponent();
            _model = model;
            Refresh();
        }

        private void Refresh()
        {
            Customers.ItemsSource = _model.Customers.OrderBy(c => c.LastName);
            Customers.SelectedIndex = 0;
            
            PriorityComboBox.ItemsSource = Enum.GetValues(typeof(PriorityPolishNames));
            PriorityComboBox.SelectedIndex = 0;

            Amount.Text = "2,5";

            InCalendar.SelectedDate = null;
            OutCalendar.SelectedDate = null;
            Info.Text = string.Empty;
        }

        private void NewOrderPanel_OnLoaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void DismissOnClick(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void SubmitOnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = Customers.SelectedValue as Customer;
                var amount = Convert.ToDouble(Amount.Text);
                if (amount <= 0)
                {
                    throw new IndexOutOfRangeException();
                }

                var priority = (Priority) PriorityComboBox.SelectedValue;
                DateTime dateIn = InCalendar.SelectedDate != null
                    ? InCalendar.SelectedDate.Value
                    : throw new ArgumentNullException();

                DateTime dateOut = OutCalendar.SelectedDate != null
                    ? OutCalendar.SelectedDate.Value
                    : throw new ArgumentNullException();

                if (dateOut < dateIn)
                {
                    throw new DataException();
                }
                
                AddOrder(customer, amount, priority, dateIn, dateOut);
            }
            catch (FormatException)
            {
                Info.Text = "Nieprawidłowa postać liczby.";
            }
            catch (IndexOutOfRangeException)
            {
                Info.Text = "Kilogramy powinny być liczbą dodatnią";
            }
            catch (ArgumentNullException)
            {
                Info.Text = "Wybierz date";
            }
            catch (DataException)
            {
                Info.Text = "Data realizacji nie może być wcześniejsza niż data przyjęcia";
            }
        }

        private void AddOrder(Customer customer, double amount, Priority priority, DateTime dateIn, DateTime dateOut)
        {
            var newOrder = new  Order()
            {
                Customer = customer,
                Amount = (float) amount,
                DateOfOrder = dateIn,
                DateOfRealization = dateOut,
                Priority = priority,
                Status = OrderStatus.Waiting
            };
            OrderAdded?.Invoke(this, new NewOrderEventArgs(newOrder));
            Refresh();
        }
    }
}