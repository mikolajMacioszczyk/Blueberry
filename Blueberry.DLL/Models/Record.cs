namespace Blueberry.DLL.Models
{
    public class Record
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Message { get; set; }
    }
}