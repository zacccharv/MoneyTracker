using System.Text.Json;
using MoneyTracker.Managers;
using MoneyTracker.WriteSystem;

namespace MoneyTracker;
class Program
{
    static void Main(string[] args)
    {
        AppDataManager.LoadData();

        // change it to "access Bank, Credit, or Subscription"
        // Bank -Set Monthly Income -Add Transaction
        // Credit -Set Limit -add transaction
        // Subscription -add item
        ConsoleTxt.WriteColor("What would you like to do: [1] Set monthly income, [2] Set credit limit, [3] Add Transaction to Accounts... ", 
            ("{[1]}", ConsoleColor.DarkYellow), 
            ("{[2]}", ConsoleColor.DarkYellow),
            ("{[3]}", ConsoleColor.DarkYellow));

        int _selection = 0;

        _selection = SelectionInput(3);

        if (_selection == 1)
        {
            Console.Write("Set Amount> ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            AppDataManager.appData.BankAccount.SetMonthlyIncome(_selection);
            AppDataManager.SetTotalMoney();

            SaveLoadSystem.SaveData(AppDataManager.appData);

            Environment.Exit(0);
        }
        if (_selection == 2)
        {
            Console.Write("Set Amount> ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            AppDataManager.appData.CreditCard.SetCreditCap(_selection);
            AppDataManager.SetTotalMoney();

            AppDataManager.SaveData(AppDataManager.appData);

            Environment.Exit(0);
        }
        if (_selection == 3)
        {
            ConsoleTxt.WriteColor("Choose account to acces: [1] Bank Account, [2] Credit Card...", 
                ("{[1]}", ConsoleColor.DarkYellow), 
                ("{[2]}", ConsoleColor.DarkYellow));
    
            // coroutine this
            _selection = SelectionInput(2);
            AppDataManager.EntryAdder(_selection);
            AppDataManager.SetTotalMoney();
    
            Console.WriteLine($"Your new account totals: Bank Account, Credit Card{AppDataManager.appData.BankAccount.Amount} + Credit Card {AppDataManager.appData.CreditCard.Amount}.");
    
            Console.WriteLine($"Total Money Available: {AppDataManager.appData.TotalMoney}");
    
            AppDataManager.SaveData(AppDataManager.appData);
        }
    }

    private static int SelectionInput(int numberOfOptions)
    {
        Console.WriteLine("");
        Console.Write("Enter Number> ");

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