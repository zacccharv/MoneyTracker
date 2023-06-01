using System.Text.Json;
using MoneyTracker.Managers;
using MoneyTracker.WriteSystem;

using static MoneyTracker.Managers.AppDataManager;

namespace MoneyTracker;
class Program
{
    static void Main(string[] args)
    {
        LoadData();
        appData.BankAccount.AddMonthlyIncome();

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
            Console.Write("Set Amount: ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            appData.BankAccount.SetMonthlyIncome(_selection);

            SaveLoadSystem.SaveData(appData);

            Environment.Exit(0);
        }
        if (_selection == 2)
        {
            Console.Write("Set Amount: ");

            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out _selection);

            appData.CreditCard.SetCreditCap(_selection);

            SaveData(appData);

            Environment.Exit(0);
        }

        ConsoleTxt.WriteColor("Choose account to acces: [1] Bank Account, [2] Credit Card...", 
            ("{[1]}", ConsoleColor.DarkYellow), 
            ("{[2]}", ConsoleColor.DarkYellow));

        _selection = SelectionInput(2);
        appData = EntryAdder(appData, _selection);

        Console.WriteLine($"Your new account totals: Bank Account, Credit Card{appData.BankAccount.Amount} + Credit Card {appData.CreditCard.Amount}.");

        appData.TotalMoney = appData.BankAccount.Amount - appData.CreditCard.Amount;
        Console.WriteLine($"Total Money Available: {appData.TotalMoney}");

        SaveData(appData);
    }
    private static AppData EntryAdder(AppData appData, int account)
    {

        if (account == 1)
        {
            appData.BankAccount.AddEntry();
        }
        else if (account == 2)
        {
            appData.CreditCard.AddCreditEntry();
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