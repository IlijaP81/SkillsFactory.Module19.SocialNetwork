namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Show success message on console
/// </summary>
public class SuccessMessage
{
    public static void Show(string message)
    {
        ConsoleColor consoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ForegroundColor = consoleColor;
    }
}
