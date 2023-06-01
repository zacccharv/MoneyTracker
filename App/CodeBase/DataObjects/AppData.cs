using MoneyTracker.Data.LineItems;

namespace MoneyTracker;

public class AppData
{
    public int DuplicateNum { get; set; }
    public BankAccount BankAccount { get; set; }
    public CreditCard CreditCard { get; set; }
    public MonthlyExpenses MonthlyExpenses { get; set; }
    public int TotalMoney { get; set; }
    public AppData()
    {
        DuplicateNum = 0;
        BankAccount = new BankAccount();
        CreditCard = new CreditCard();
        MonthlyExpenses = new MonthlyExpenses();
        TotalMoney = 0;
    }

}
