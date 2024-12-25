namespace SocialNetwork.PLL.Helpers;

/// <summary>
/// Show info message on console
/// </summary>
public class InfoMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}


