namespace MoneyTracker.DataObjects.LineItems;

public class BankAccount : LineItemBase
{
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
        bool canRenew = StartDate.Month < DateTime.Today.Month 
        || (StartDate.Month > DateTime.Today.Month && StartDate.Year < DateTime.Today.Year);

        if (canRenew)
        {
            Entries.Add("Monthly Income", MonthlyIncome);
        }
    }
    public void SetMonthlyIncome(int amount)
    {
        MonthlyIncome = amount;
        Amount = amount;
    }
}
