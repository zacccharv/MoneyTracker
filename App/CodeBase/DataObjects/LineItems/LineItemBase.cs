using MoneyTracker.DataObjectsUtilities;

namespace MoneyTracker.DataObjects.LineItems;

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

    public void AddEntry()
    {
        Console.Write("Enter Name> ");

        string? strName = ConsoleTxt.ReadInput();
        string name = strName == null ? "" : strName;

        if (name == "")
        {
            ConsoleTxt.ErrorMessage("Please enter a descriptor!");
            AddEntry();
        }

        Console.Write("Enter Amount> ");

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
            (string name, int amount) entry = (name, num);
            entry = DataUtils.DuplicateKeyChecker(entry, Entries);

            Entries.Add(entry.name, entry.amount);
            Amount += num;

            Console.WriteLine($"Your new {Name} total is {Amount}");
        }
    }
    public void AddEntry((string name, int amount) entry)
    {
        entry = DataUtils.DuplicateKeyChecker(entry, Entries);
        Entries.Add(entry.name, entry.amount);

        Amount += entry.amount;
    }

    public (string name, int amount) SetEntryName()
    {
        Console.Write("Enter Name> ");

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
        Console.Write("Enter Amount> ");

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
