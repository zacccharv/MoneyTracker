using System.Text.RegularExpressions;

namespace MoneyTracker;

public static class ConsoleTxt
{
    public static void WriteColor(string str, params (string substring, ConsoleColor color)[] colors)
    {
        var words = Regex.Split(str, @"( )");

        foreach (var word in words)
        {
            (string substring, ConsoleColor color) cl = colors.FirstOrDefault(x => x.substring.Equals("{" + word + "}"));
            if (cl.substring != null)
            {
                Console.ForegroundColor = cl.color;
                Console.Write(cl.substring.Substring(1, cl.substring.Length - 2));
                Console.ResetColor();
            }
            else
            {
                Console.Write(word);
            }
        }
    }

    public static string? ReadInput()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        string? _selectAccount = Console.ReadLine();
        Console.ResetColor();
        
        return _selectAccount;
    }

    public static void ErrorMessage(string errorMessage)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(errorMessage);
        Console.ResetColor();
    }    
}
