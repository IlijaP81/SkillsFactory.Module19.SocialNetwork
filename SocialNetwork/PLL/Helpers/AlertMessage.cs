namespace SocialNetwork.PLL.Helpers;


/// <summary>
/// Show alert message on console
/// </summary>
public class AlertMessage
{
    public static void Show(string message)
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }
}
