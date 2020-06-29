using Blueberry.DLL.Models;

namespace Blueberry.WPF.PageEventArgs
{
    public class CustomerAddedEventArgs
    {
        public Customer Customer { get; set; }
        public bool IsAddressNew { get; set; }

        public CustomerAddedEventArgs(Customer customer, bool isAddressNew)
        {
            Customer = customer;
            IsAddressNew = isAddressNew;
        }
    }
}