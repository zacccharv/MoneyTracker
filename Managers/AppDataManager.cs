using MoneyTracker.WriteSystem;

namespace MoneyTracker.Managers;

public static class AppDataManager 
{
    public static AppData appData;
    static AppDataManager()
    {
        appData = new AppData();
    }
    public static void LoadData()
    {
        appData = SaveLoadSystem.LoadData();
    }
    
    public static void SaveData(AppData appData)
    {
        SaveLoadSystem.SaveData(appData);
    }
}
