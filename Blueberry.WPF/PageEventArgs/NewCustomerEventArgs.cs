namespace Blueberry.WPF.PageEventArgs
{
    public class NewCustomerEventArgs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int House { get; set; }

        public NewCustomerEventArgs(string firstName, string lastName, string phoneNumber, string city, string street, int house)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            City = city;
            Street = street;
            House = house;
        }
    }
}