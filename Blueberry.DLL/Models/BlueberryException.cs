namespace Blueberry.DLL.Models
{
    public class BlueberryException
    {
        public int Id { get; set; }
        public string StackTrance { get; set; }
        public bool IsSolved { get; set; } = false;
    }
}