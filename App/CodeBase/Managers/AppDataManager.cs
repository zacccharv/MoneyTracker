using MoneyTracker.WriteSystem;

namespace MoneyTracker.Managers;

public static class AppDataManager 
{
    public static AppData appData;
    private static bool _monthResetDay;
    public static int _duplicateNum = 0;

    static AppDataManager()
    {
        appData = new AppData();

        SaveLoadSystem.onLoaded += MonthlyDataUpdate;
        SaveLoadSystem.onSaved += SetTotalMoney;
    }
    public static void LoadData()
    {
        appData = SaveLoadSystem.LoadData();
        SaveLoadSystem.TriggeronLoaded();
    }
    
    public static void SaveData(AppData appData)
    {
        SaveLoadSystem.SaveData(appData);
    }

    public static void EntryAdder(int account)
    {
        if (account == 1)
        {
            appData.BankAccount.AddEntry();
        }
        else if (account == 2)
        {
            appData.CreditCard.AddCreditEntry();
        }
    }

    public static void MonthlyDataUpdate()
    {
        if (appData.BankAccount.StartDate.Day != DateTime.Today.Day) _monthResetDay = false;

        if (appData.BankAccount.StartDate.Day == DateTime.Today.Day && _monthResetDay == false)
        {
            _monthResetDay = true;
            appData.CreditCard.AllCreditToBank();
            appData.BankAccount.AddMonthlyIncome();
        }
    }

    public static void SetTotalMoney()
    {
        AppDataManager.appData.TotalMoney = AppDataManager.appData.BankAccount.Amount - AppDataManager.appData.CreditCard.Amount;
    }

}
