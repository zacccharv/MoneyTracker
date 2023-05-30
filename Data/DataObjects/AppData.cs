using MoneyTracker.Data.LineItems;

namespace MoneyTracker;

public class AppData
{
    public List<LineItemBase> Items { get; set; }
    public int TotalMoney { get; set; }
    public AppData()
    {
        Items = new List<LineItemBase>{new BankAccount(), new CreditCard()};
        TotalMoney = 0;
    }

}
