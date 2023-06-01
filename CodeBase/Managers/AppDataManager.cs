using MoneyTracker.WriteSystem;

namespace MoneyTracker.Managers;

public static class AppDataManager 
{
    public static AppData appData;
    static AppDataManager()
    {
        appData = new AppData();

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

    private static void SetTotalMoney()
    {
        AppDataManager.appData.TotalMoney = AppDataManager.appData.BankAccount.Amount - AppDataManager.appData.CreditCard.Amount;
    }
}
