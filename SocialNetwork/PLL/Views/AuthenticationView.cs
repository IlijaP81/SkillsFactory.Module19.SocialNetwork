using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class AuthenticationView
{
    UserService userService;
    public AuthenticationView(UserService userService)
    {
        this.userService = userService;
    }

    /// <summary>
    /// Authenticates user by email and password
    /// </summary>
    public void Show()
    {
        var userMenuView = new UserMenuView(userService);
        var authenticationData = new UserAuthenticationData();
        Console.WriteLine("Введите почтовый адрес:");
        authenticationData.Email = Console.ReadLine();
        Console.WriteLine("Введите пароль:");
        authenticationData.Password = Console.ReadLine();

        try
        {
            var user = userService.Authenticate(authenticationData);
            Console.WriteLine("Вы успешно вошли в социальную сеть! Добро пожаловать {0}", user.FirstName);
            userMenuView.Show(user);
        }
        // other exeptions process in UserService class
        catch (Exception ex)
        {
            AlertMessage.Show("Произошла ошибка: " + ex.Message);
        }
    }
}
