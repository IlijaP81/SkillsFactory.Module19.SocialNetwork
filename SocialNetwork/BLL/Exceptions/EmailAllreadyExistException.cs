using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Exceptions;

/// <summary>
/// Processes exception for case - Email allready exist
/// </summary>
public class EmailAllreadyExistException : Exception
{
    public EmailAllreadyExistException()
    {
        AlertMessage.Show("Пользователь с таким адресом уже существует");
    }
}
