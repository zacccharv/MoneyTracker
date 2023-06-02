using MoneyTracker.DataObjectsUtilities;

namespace MoneyTracker.DataObjects.LineItems;

public class CreditCard : LineItemBase
{
    public delegate void creditToBankEventHandler((string name, int amount) resetEntry);
    public static creditToBankEventHandler? creditToBank;

    public int CreditCap { get; set; } = 0;

    public CreditCard()
    {
        Name = "Credit Card";
    }
    
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
            ConsoleTxt.ErrorMessage("Amount exceeds limit!");
            Environment.Exit(0);
        }

        (string , int) newEntry = DataUtils.DuplicateKeyChecker(entry, Entries);
        Entries.Add(entry.name, entry.amount);
        
        Amount += entry.amount;
    }

    public void AllCreditToBank()
    {
        creditToBank?.Invoke(("Monthly Credit Total", Amount));

        Amount = 0;
    }
}