namespace MoneyTracker.Data.LineItems;

public class CreditCard : LineItemBase
{
    public int CreditCap { get; set; } = 0;
    public void SetCreditCap(int creditCap)
    {
        CreditCap = creditCap;
    }
    public void AddCreditEntry()
    {
        (string name, int amount) entry = SetEntryName();

        entry = SetEntryAmount(entry);

        if (Amount + entry.amount > CreditCap)
        {
            ConsoleTxt.ErrorMessage("Amount exceeds limit");
            Environment.Exit(0);
        }

        Entries.Add(entry.name, entry.amount);
        Amount += entry.amount;
    }
}