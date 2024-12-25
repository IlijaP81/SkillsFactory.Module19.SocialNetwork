using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class UserDeletingView
{
    /// <summary>
    /// Delete user's data. Informs user about the status.
    /// </summary>
    /// <param name="user"></param>
    public void Show(User user)
    {
        try
        {
            if (Program.userService.Delete(user.Id) == 0)
            {

                AlertMessage.Show("Сведения о пользователе удалены не были");
                throw new Exception();
            }
            else
            {
                SuccessMessage.Show("Удалены профиль пользователя, сведения о друзьях" +
                    " и переписка");
            }
        }
        catch (Exception ex)
        {
            AlertMessage.Show("Произошла ошибка " + ex.Message);
        }
    }
}
