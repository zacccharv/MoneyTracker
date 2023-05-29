namespace MoneyTracker.Data.LineItems;

public class CreditCard : ILineItems
{
    string _name = "CreditCard";
    public Dictionary<string, int> Entries { get; set; } = new Dictionary<string, int>();
    public int Amount { get; private set; }

    public CreditCard(int startAmount = 0)
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
            Console.WriteLine($"Your new credit total is {Amount}");
        }
    }
}
    
