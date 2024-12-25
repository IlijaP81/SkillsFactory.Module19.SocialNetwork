using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Exceptions;

/// <summary>
/// Processes exception for case - Invalid email format
/// </summary>
public class InvalidEmailFormatException : Exception
{
    public InvalidEmailFormatException()
    {
        AlertMessage.Show("Некорректный формат электронной почты. Используйте *@*.*");
    }
}
