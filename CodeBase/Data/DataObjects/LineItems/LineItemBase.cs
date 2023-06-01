namespace MoneyTracker.Data.LineItems;

public class LineItemBase
{
    public DateTime StartDate { get; set; }
    public string Name { get; set; } = "";
    public SortedList<string , int> Entries { get; set; } = new SortedList<string , int>();
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
    public void AddEntry()
    {
        Console.WriteLine("Name: ");

        string? strName = ConsoleTxt.ReadInput();
        string name = strName == null ? "" : strName;

        if (name == "")
        {
            ConsoleTxt.ErrorMessage("Please enter a descriptor!");
            AddEntry();
        }

        Console.WriteLine("Amount:");

        string? strNum = ConsoleTxt.ReadInput();

        int num = 0;
        int.TryParse(strNum, out num);

        if (num == 0)
        {
            ConsoleTxt.ErrorMessage("Please enter amount!");
            AddEntry();
        }
        else
        {
            Entries.Add(name , num);
            Amount += num;
            Console.WriteLine($"Your new {Name} total is {Amount}");
        }
    }
    public (string name, int amount) SetEntryName()
    {
        Console.Write("Name: ");

        string? strName = ConsoleTxt.ReadInput();
        string localName = strName == null ? "" : strName;

        if (localName == "")
        {
            ConsoleTxt.ErrorMessage("Please enter a descriptor!");
            SetEntryName();
        }

        return (localName, 0);
    }
    public (string name, int amount) SetEntryAmount((string name, int amount) entry)
    {
        Console.Write("Amount: ");

        string? strNum = ConsoleTxt.ReadInput();

        int num = 0;
        int.TryParse(strNum, out num);

        if (num == 0)
        {
            ConsoleTxt.ErrorMessage("Please enter amount!");
            SetEntryAmount(entry);
        }
        return (entry.name, num);
    }
}
