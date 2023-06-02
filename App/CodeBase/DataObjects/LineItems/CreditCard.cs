using MoneyTracker.DataObjectsUtilities;

namespace MoneyTracker.DataObjects.LineItems;

public class CreditCard : LineItemBase
{
    public delegate void creditToBankEventHandler((string name, int amount) resetEntry);
    public static creditToBankEventHandler? creditToBank;
    public bool NotNewMonth { get; set; } = false;
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
            Program.Start();
        }

        (string , int) newEntry = DataUtils.DuplicateKeyChecker(entry, Entries);
        Entries.Add(entry.name, entry.amount);
        
        Amount += entry.amount;
    }

    public void AllCreditToBank()
    {
        bool canRenewDate = (StartDate.Day == DateTime.Today.Day && (StartDate.Month != DateTime.Today.Month || StartDate.Year != DateTime.Today.Year));
        
        if (canRenewDate && !NotNewMonth)
        {        
            creditToBank?.Invoke(("Monthly Credit Total", Amount));
            Amount = 0;

            NotNewMonth |= canRenewDate;  
        }

        NotNewMonth |= canRenewDate;
    }
}