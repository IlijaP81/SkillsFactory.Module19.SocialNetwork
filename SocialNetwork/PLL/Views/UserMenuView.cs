using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views;

public class UserMenuView
{
    UserService userService;
    public UserMenuView(UserService userService)
    {
        this.userService = userService;
    }
    /// <summary>
    /// Provide user's menu after authentification
    /// </summary>
    /// <param name="user"></param>
    public void Show(User user)
    {
        while (true)
        {
            MessageService messageService = new MessageService();
            Console.WriteLine("Входящие сообщения: " + Program.userIncomingMessageView.Show(user)); 
            Console.WriteLine("Исходящие сообщения: " + Program.userOutcomingMessageView.Show(user));
            Console.WriteLine("Просмотреть информацию о всех пользователях социальной сети (нажмите 0)");
            Console.WriteLine("Просмотреть информацию о своём профиле (нажмите 1)");
            Console.WriteLine("Редактировать мой профиль (нажмите 2)");
            Console.WriteLine("Показать друзей (нажмите 3)");
            Console.WriteLine("Добавить в друзья (нажмите 4)");
            Console.WriteLine("Исключить из друзей (нажмите 5)");
            Console.WriteLine("Написать сообщение (нажмите 6)");
            Console.WriteLine("Просмотреть входящие сообщения (нажмите 7)");
            Console.WriteLine("Просмотреть исходящие сообщения (нажмите 8)");
            Console.WriteLine("Удалить сообщение (нажмите 9)");
            Console.WriteLine("Удалить свой профиль и все относящиеся к нему сведения (нажмите 10)");
            Console.WriteLine("Выйти из профиля (нажмите 11)");

            string keyValue = Console.ReadLine();
            if (keyValue == "11") break; // quit user's profile
            switch (keyValue)
            {
                case "0":
                    {
                        Program.userInfoView.Show(user);
                        break;
                    }
                
                case "1": // show user's profile
                    {
                        Program.userInfoView.Show(user, 1);
                        break;
                    }
                case "2": // update user's profile
                    {
                        Program.userDataUpdateView.Show(user);
                        break;
                    }
                case "3": // show users friends
                    {
                        Program.friendDataUpdateView.Show(user, 0);
                        break;
                    }
                case "4": // append user's friend
                    {
                        Program.friendDataUpdateView.Show(user, 1);
                        break;
                    }
                case "5": // delete user's friend
                    {
                        Program.friendDataUpdateView.Show(user, 2);
                        break;
                    }
                case "6": // write message
                    {
                        Program.messageSendingView.Show(user);
                        break;
                    }
                case "7": // show incoming messages
                    {
                        Program.userIncomingMessageView.Show(user, 1);
                        break;
                    }
                case "8": // show outcoming messages
                    {
                        Program.userOutcomingMessageView.Show(user, 1);
                        break;
                    }
                case "9": // delete message
                    {
                        Program.messageDeletingView.Show(user);
                        break;
                    }
                case "10": // delete user
                    {
                        Program.userDeletingView.Show(user);
                        break;
                    }
            }
        }
    }
}
