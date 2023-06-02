namespace MoneyTracker.DataObjects.LineItems;

public class BankAccount : LineItemBase
{
    public bool NotNewMonth { get; set; } = false;

    public int MonthlyIncome { get; set; } = 0;

    public BankAccount() 
    {
        CreditCard.creditToBank += Withdrawal;

        Name = "Bank Account";
    }

    public void Withdrawal()
    {
        (string name, int amount) entry = SetEntryName();
        entry = SetEntryAmount(entry);

        entry.amount *= -1;

        AddEntry(entry);
    }
    public void Withdrawal((string name, int amount) entry)
    {
        AddEntry(entry);
    }
    public void Deposit(int amount)
    {
        (string name, int amount) entry = SetEntryName();
        entry = SetEntryAmount(entry);

        AddEntry(entry);
    }

    public void AddMonthlyIncome()
    {
        bool canRenewDate = (StartDate.Day == DateTime.Today.Day && (StartDate.Month != DateTime.Today.Month || StartDate.Year != DateTime.Today.Year));
        
        if (canRenewDate && !NotNewMonth)
        {        
            NotNewMonth |= canRenewDate;            
            Entries.Add("Monthly Income", MonthlyIncome);
        }

        NotNewMonth |= canRenewDate;
    }
    public void SetMonthlyIncome(int amount)
    {
        MonthlyIncome = amount;
        Amount = amount;
    }
}
