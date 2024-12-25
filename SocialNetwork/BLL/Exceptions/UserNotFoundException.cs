using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Exceptions;


/// <summary>
/// Processes exception for case - User not found
/// </summary>
public class UserNotFoundException : Exception
{
    public UserNotFoundException()
    {
        AlertMessage.Show("Пользователь не найден");
    }
}
