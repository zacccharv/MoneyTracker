using System.Text.Json;
using MoneyTracker.Managers;
using MoneyTracker.WriteSystem;

namespace MoneyTracker;
class Program
{
    static void Main(string[] args)
    {
        #region Notes
        // Create a new user flow

        // [1]
        // What would you like to do: [1] Access Accounts, [2] Access Monthly Expenses, [3] Exit 

        //**IF [1.1]**
        //[1] Access Bank Account, [2] Access Credit Account, [3] Exit 

        //**IF [1.1.1]**
        // [1] Set Income, [2] Add Transaction, [3] Exit

        //**IF [1.1.1.2]**
        // [1] Withdrawal, [2] Deposit, [3] Exit       

        //**IF [1.1.2]
        // [1] Set Credit Cap, [2] Add Purchase, [3] Exit

        //**IF [1.2]**
        // [1] Add Monthly Expense, [2] Remove Monthly Expense, [3] Exit

        // return to start
        #endregion
        Start();
    }
    public static void Start()
    {
        AppDataManager.LoadData();

        string text1 = "What would you like to do: [1] Set monthly income, [2] Set credit limit, [3] Add Transaction to Accounts... ";

        int _selection = 0;

        _selection = SelectionInput(3, text1).Result;

        if (_selection == 1)
        {
            Console.Write("Set Amount> ");

            int newSelection = 0;
            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out newSelection);

            AppDataManager.appData.BankAccount.SetMonthlyIncome(newSelection);
            AppDataManager.SetTotalMoney();

            SaveLoadSystem.SaveData(AppDataManager.appData);

            Start();
        }
        if (_selection == 2)
        {
            Console.Write("Set Amount> ");

            int newSelection = 0;
            string? strNum = ConsoleTxt.ReadInput();
            int.TryParse(strNum, out newSelection);

            AppDataManager.appData.CreditCard.SetCreditCap(newSelection);
            AppDataManager.SetTotalMoney();

            AppDataManager.SaveData(AppDataManager.appData);

            Start();
        }
        if (_selection == 3)
        {
            string text3 = "Choose account to acces: [1] Bank Account, [2] Credit Card...";

            // coroutine this
            int newSelection = 0;
            newSelection = SelectionInput(2, text3).Result;

            AppDataManager.EntryAdder(newSelection);

            AppDataManager.SetTotalMoney();

            Console.WriteLine($"Your new account totals: Bank Account: {AppDataManager.appData.BankAccount.Amount}, Credit Card: {AppDataManager.appData.CreditCard.Amount}.");

            Console.WriteLine($"Total Money Available: {AppDataManager.appData.TotalMoney}");

            AppDataManager.SaveData(AppDataManager.appData);
            Start();
        }
    }
    public static void Tick()
    {
        Console.WriteLine("ticking");
        Tick();
    }
    private static async Task<int> SelectionInput(int numberOfOptions, string selectionText)
    {
        ConsoleTxt.WriteColor(selectionText,
            ("{[1]}", ConsoleColor.DarkYellow),
            ("{[2]}", ConsoleColor.DarkYellow),
            ("{[3]}", ConsoleColor.DarkYellow),
            ("{[4]}", ConsoleColor.DarkYellow));

        Console.WriteLine("");
        Console.Write("Enter Number> ");

        string? selectAccountStr = ConsoleTxt.ReadInput();

        int selectedAccount = 0;
        int.TryParse(selectAccountStr, out selectedAccount);

        bool inRangeCheck()
        {
            if (selectedAccount > numberOfOptions || selectedAccount < 1)
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

            selectedAccount = await SelectionInput(numberOfOptions, selectionText);
        }

        return selectedAccount;
    }
}