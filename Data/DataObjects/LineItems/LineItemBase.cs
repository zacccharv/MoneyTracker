namespace MoneyTracker.Data.LineItems;

public class LineItemBase
{
    public DateTime StartDate { get; set; }
    public string Name { get; set; } = "";
    public List<int> Entries { get; set; } = new List<int>();
    public int Amount { get; set; } = 0;
    
    public LineItemBase()
    {
        StartDate = DateTime.Today;
    }
    public LineItemBase(string name)
    {
        StartDate = DateTime.Today;
        Name = name;
    }
    public void AddEntry(int value)
    {
        if (value == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine("No amount given.");
            Console.ResetColor();
        }
        else
        {
            Entries.Add(value);
            Amount += value;
            Console.WriteLine($"Your new {Name} total is {Amount}");
        }
    }
}
