using System.Text.Json;

namespace MoneyTracker.WriteSystem;

public static class SaveLoadSystem
{
    static string _path = $@"{Directory.GetCurrentDirectory()}\Data\Database\MoneyData.json";
    static JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
    static SaveLoadSystem()
    {
        jsonOptions.WriteIndented = true;
    }
    public static AppData LoadData(AppData appData)
    {
        if (!File.Exists(_path))
        {
            File.Create(_path);
            Console.WriteLine("Money Data file created.");
            Environment.Exit(0);
        }

        if (File.ReadAllText(_path).Count() < 5)
        {
            string jsonString = JsonSerializer.Serialize(appData, jsonOptions);
            Console.WriteLine(jsonString);
            File.WriteAllText(_path, jsonString);
            return appData;
        }
        
        string jsonDeserializeStr = File.ReadAllText(_path);

        AppData? inner = JsonSerializer.Deserialize<AppData>(jsonDeserializeStr);

        if (inner != null)
        {
            appData = inner;
        }

        return appData;
    }
    public static void SaveData(AppData data)
    {
        string jsonString = JsonSerializer.Serialize(data, jsonOptions);
        
        if (File.Exists(_path))
        {
            Console.WriteLine(jsonString);
            File.WriteAllText(_path, jsonString);
        } 
        else if (!File.Exists(_path))
        {
            File.Create(_path);
            File.WriteAllText(_path, jsonString);
        }
    }
}
