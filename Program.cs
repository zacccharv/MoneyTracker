using System.Text.Json;
using MoneyTracker.WriteSystem;

namespace MoneyTracker;
class Program
{
    private static string? _path;

    static void Main(string[] args)
    {
        _path = $@"{Directory.GetCurrentDirectory()}\Data\Database\MoneyData.json";
        if (!File.Exists(_path))
        {
            File.Create(_path);
        }
        
        AppData _appData = SaveLoadSystem.LoadData(new AppData());
        Console.WriteLine("Choose account to acces: [1] Bank Account, [2] Credit Card...");

        _appData = BankSelecter(_appData);

        Console.WriteLine($"Your new account totals: Bank Account, Credit Card{_appData.Items[0].Amount} + Credit Card {_appData.Items[1].Amount}.");

        _appData.TotalMoney = _appData.Items[0].Amount + _appData.Items[1].Amount;
        Console.WriteLine($"Total Money Available: {_appData.TotalMoney}");

        SaveLoadSystem.SaveData(_appData);
    }

    private static AppData BankSelecter(AppData appData)
    {        
        string? _selectedAccount = Console.ReadLine();

        if (_selectedAccount != "1" && _selectedAccount != "2")
        {
            Console.WriteLine("Please select a bank account");
            
            BankSelecter(appData);
        }

        if (_selectedAccount == "1")
        {
            Console.WriteLine("Amount:");
            string? strNum = Console.ReadLine();

            int num = 0;
            int.TryParse(strNum, out num);

            appData.Items[0].AddEntry(num);
            return appData;
        }
        else if (_selectedAccount == "2")
        {
            Console.WriteLine("Amount:");
            string? strNum = Console.ReadLine() as string;

            int num = 0;
            int.TryParse(strNum, out num);

            appData.Items[1].AddEntry(num);
            return appData;
        }

        return new AppData();
    }
}
