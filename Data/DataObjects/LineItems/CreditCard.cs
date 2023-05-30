namespace MoneyTracker.Data.LineItems;

public class CreditCard : LineItemBase
{
    public int CreditCap { get; set; } = 0;
    public void SetCreditCap(int creditCap)
    {
        CreditCap = creditCap;
    }
    public void AddCreditEntry(int amount)
    {
        if (Amount + amount > CreditCap)
        {
            ConsoleTxt.ErrorMessage("Amount exceeds limit");
            Environment.Exit(0);
        }

        AddEntry(amount);
    }
}