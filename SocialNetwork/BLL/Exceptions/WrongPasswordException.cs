using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Exceptions;

/// <summary>
/// Processes exception for case - Wrong password typed
/// </summary>
public class WrongPasswordException : Exception
{
    public WrongPasswordException()
    {
        AlertMessage.Show("Введите верный пароль длиной не менее 8 символов");
    }
}
