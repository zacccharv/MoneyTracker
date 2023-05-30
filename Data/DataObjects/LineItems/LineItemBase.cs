namespace MoneyTracker.Data.LineItems;

public class LineItemBase
{
    public string Name { get; set; } = "";
    public List<int> Entries { get; set; } = new List<int>();
    public int Amount { get; set; } = 0;
    public virtual void AddEntry(int value)
    {
        if (value == 0)
        {
            Console.Error.WriteLine("No amount given.");
        }
        else
        {
            Entries.Add(value);
            Amount += value;
            Console.WriteLine($"Your new {Name} total is {Amount}");
        }
    }
}