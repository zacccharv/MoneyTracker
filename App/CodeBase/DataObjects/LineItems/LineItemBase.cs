using MoneyTracker.Managers;

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
        Console.WriteLine("Enter Name> ");

        string? strName = ConsoleTxt.ReadInput();
        string name = strName == null ? "" : strName;

        if (name == "")
        {
            ConsoleTxt.ErrorMessage("Please enter a descriptor!");
            AddEntry();
        }


        Console.WriteLine("Enter Amount> ");

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
            if (Entries.ContainsKey(name))
            {
                (string , int) entry = (name, num);
                entry = DuplicateKeyNamer(entry);
                Entries.Add(entry.Item1 , entry.Item2);
            }
            else
            {
                Entries.Add(name , num);
            }
            Amount += num;
            Console.WriteLine($"Your new {Name} total is {Amount}");
        }
    }
    public void AddEntry((string name, int amount) entry)
    {
        if (Entries.ContainsKey(entry.name))
        {
            (string , int) newEntry = DuplicateKeyNamer(entry);

            Entries.Add(newEntry.Item1, entry.amount);
        }
        else
        {
            Entries.Add(entry.name, entry.amount);
        }
        Amount += entry.amount;
    }

    private (string name, int amount) DuplicateKeyNamer((string name, int amount) entry)
    {
        AppDataManager.appData.DuplicateNum++;
        entry.name += $"{AppDataManager.appData.DuplicateNum}";

        return entry;
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
