using System.Text.Json;
using MoneyTracker.WriteSystem;

namespace MoneyTracker;
class Program
{
    static void Main(string[] args)
    {
        AppData _appData = SaveLoadSystem.LoadData(new AppData());        
        int _selection = 0;

        _appData.BankAccount.AddMonthlyIncome();

        // change it to "access Bank, Credit, or Subscription"
        // Bank -Set Monthly Income -Add Transaction
        // Credit -Set Limit -add transaction
        // Subscription -add item
        ConsoleTxt.WriteColor("What would you like to do: [1] Set monthly income, [2] Set credit limit, [3] Add Transaction to Accounts... ", 
            ("{[1]}", ConsoleColor.DarkYellow), 
            ("{[2]}", ConsoleColor.DarkYellow),
            ("{[3]}", ConsoleColor.DarkYellow));

        // access selection
        _selection = SelectionInput(3);

        if (_selection == 1)
        {
            Console.Write("Set Amount: ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            _appData.BankAccount.SetMonthlyIncome(_selection);
            _appData.TotalMoney = _appData.BankAccount.Amount - _appData.CreditCard.Amount;

            SaveLoadSystem.SaveData(_appData);

            Environment.Exit(0);
        }
        if (_selection == 2)
        {
            Console.Write("Set Amount: ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            _appData.CreditCard.SetCreditCap(_selection);

            SaveLoadSystem.SaveData(_appData);

            Environment.Exit(0);
        }
        if (_selection == 3)
        {
            ConsoleTxt.WriteColor("Choose account to acces: [1] Bank Account, [2] Credit Card...", 
                ("{[1]}", ConsoleColor.DarkYellow), 
                ("{[2]}", ConsoleColor.DarkYellow));

            _selection = SelectionInput(2);
            _appData = EntryAdder(_appData, _selection);
        }

        Console.WriteLine($"Your new account totals: Bank Account, Credit Card{_appData.BankAccount.Amount} + Credit Card {_appData.CreditCard.Amount}.");

        _appData.TotalMoney = _appData.BankAccount.Amount - _appData.CreditCard.Amount;
        Console.WriteLine($"Total Money Available: {_appData.TotalMoney}");

        SaveLoadSystem.SaveData(_appData);
    }

    private static AppData EntryAdder(AppData appData, int account)
    {
        Console.Write("Amount: ");

        string? strNum = ConsoleTxt.ReadInput();

        int num = 0;
        int.TryParse(strNum, out num);

        if (account == 1)
        {
            appData.BankAccount.AddEntry(num);
        }
        else if (account == 2)
        {
            appData.CreditCard.AddCreditEntry(num);
        }
        return appData;
    }

    private static int SelectionInput(int numberOfOptions)
    {
        string? _selectAccount = ConsoleTxt.ReadInput();

        int _selectedAccount = 0;
        int.TryParse(_selectAccount, out _selectedAccount);

        bool inRangeCheck()
        {
            if (_selectedAccount > numberOfOptions || _selectedAccount < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        if (!inRangeCheck())
        {
            ConsoleTxt.ErrorMessage("Invalid choice, pick again...");

            SelectionInput(numberOfOptions);
        }

        return _selectedAccount;
    }

}