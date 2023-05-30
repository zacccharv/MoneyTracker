using MoneyTracker.Data.LineItems;

namespace MoneyTracker;

public class AppData
{
    public BankAccount BankAccount { get; set; }
    public CreditCard CreditCard { get; set; }
    public int TotalMoney { get; set; }
    public AppData()
    {
        BankAccount = new BankAccount();
        CreditCard = new CreditCard();
        TotalMoney = 0;
    }

}
