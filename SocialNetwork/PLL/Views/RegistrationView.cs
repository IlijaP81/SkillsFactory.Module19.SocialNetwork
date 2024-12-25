using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

/// <summary>
/// Provides new user registration
/// </summary>
public class RegistrationView
{
    UserService userService;
    public RegistrationView(UserService userService)
    {
        this.userService = userService; 
    }
    public void Show()
    {
        var userMenuView = new UserMenuView(userService);
        var registrationData = new UserRegistrationData();
        Console.Write("Меня зовут:");
        registrationData.FirstName = Console.ReadLine();
        Console.Write("Моя фамилия:");
        registrationData.LastName = Console.ReadLine();
        Console.Write("Пароль:");
        registrationData.Password = Console.ReadLine();
        Console.Write("Адрес электронной почты:");
        registrationData.Email = Console.ReadLine();

        try
        {
            UserRepository userRepository = new UserRepository();
            userService.Register(registrationData);
            SuccessMessage.Show("Добро пожаловать в социальную сеть");
            InfoMessage.Show("Чтобы продолжить работу вам нужно авторизоваться");
        }
        // other exeptions process in UserService class
        catch (Exception ex)
        {
            AlertMessage.Show($"Ошибка при регистрации {ex.Message}");
        }
    }
}
