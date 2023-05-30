namespace MoneyTracker.Data.LineItems;

public class BankAccount : LineItemBase
{
    public int MonthlyIncome { get; set; } = 0;
    public BankAccount() 
    {
        Name = "Bank Account";
    }
    public void AddMonthlyIncome()
    {
        bool canRenew = StartDate.Month < DateTime.Today.Month || (StartDate.Month > DateTime.Today.Month && StartDate.Year < DateTime.Today.Year);
        if (canRenew)
        {
            AddEntry(MonthlyIncome);
        }
    }
    public void SetMonthlyIncome(int amount)
    {
        MonthlyIncome = amount;
    }
}