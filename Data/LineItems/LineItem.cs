namespace MoneyTracker.Data.LineItems;

public interface ILineItems
{
    Dictionary<string, int> Entries { get; set; }
    int Amount { get; }
    void AddEntry(int value);
}
