using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views;

public class UserInfoView
{
    /// <summary>
    /// Show user's profile (mode = 1).
    /// Show all users (mode <> 1).
    /// </summary>
    /// <param name="user"></param>
    public void Show(User user, int mode = 0)
    {
        if (mode == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Информация о моем профиле");
            Console.WriteLine("Мой идентификатор: {0}", user.Id);
            Console.WriteLine("Меня зовут: {0}", user.FirstName);
            Console.WriteLine("Моя фамилия: {0}", user.LastName);
            Console.WriteLine("Мой пароль: {0}", user.Password);
            Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
            Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
            Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
            Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Program.userService.ShowAllUsers();
        }
    }
}
