namespace MoneyTracker.Data.LineItems;

public class BankAccount : ILineItems
{
    string _name = "BankAccount";
    public Dictionary<string, int> Entries { get; set; } = new Dictionary<string, int>();
    public int Amount { get; private set; }

    public BankAccount(int startAmount = 0)
    {
        Entries.Add(_name, startAmount);
    }

    public void AddEntry(int amount)
    {
        if (amount == 0)
        {
            Console.Error.WriteLine("No amount given.");
        }
        else
        {
            Entries.Add(_name, amount);
            Amount += amount;
            Console.WriteLine($"Your new bank total is {Amount}");
        }
    }
}
    
