using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

public class UserDataUpdateView
{
    /// <summary>
    /// Provides user profile update
    /// </summary>
    public void Show(User user)
    {
        UserService userService = new UserService();
        
        Console.Write("Меня зовут:");
        user.FirstName = Console.ReadLine();

        Console.Write("Моя фамилия:");
        user.LastName = Console.ReadLine();

        Console.Write("Ссылка на моё фото:");
        user.Photo = Console.ReadLine();

        Console.Write("Мой любимый фильм:");
        user.FavoriteMovie = Console.ReadLine();

        Console.Write("Моя любимая книга:");
        user.FavoriteBook = Console.ReadLine();

        userService.Update(user);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ваш профиль успешно обновлён!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}
