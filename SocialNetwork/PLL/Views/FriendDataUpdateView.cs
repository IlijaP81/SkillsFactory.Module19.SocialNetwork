using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views;
public class FriendDataUpdateView
{
    /// <summary>
    /// Provide operations with friends for user: show all friends (mode = 0), append new friend (mode = 1), exclude existing friend (mode = 2)  
    /// </summary>
    /// <param name="user"></param>
    /// <param name="mode"></param>
    public void Show(User user, int mode)
    {
        switch (mode)
        {
            case 0: // show all friends
                {
                    List<FriendEntity> friends = Program.friendService.FindAllFriends(user);
                    if (friends.Count == 0)
                    {
                        InfoMessage.Show("У вас нет друзей среди пользователей сети");
                    }
                    else
                    {
                        InfoMessage.Show("В списке ваших друзей следующие пользователи: ");
                        foreach (FriendEntity friend in friends)
                        {
                            User userAsFriend = Program.userService.FindById(friend.friend_id);
                            InfoMessage.Show(userAsFriend.FirstName + " " +
                                              userAsFriend.LastName + " " +
                                              userAsFriend.Email);
                        }
                    }
                    break;
                }
            case 1: // append new friend
                {
                    Console.WriteLine("Укажите адрес электронной почты пользователя сети");
                    User userAsFriend = Program.userService.FindByEmail(Console.ReadLine());
                    
                    // if friend exists yet => stop the process
                    if (Program.friendService.FindSingleFriend(user, userAsFriend) != 0)
                    {
                        InfoMessage.Show($"Пользователь {userAsFriend.FirstName} " +
                                         $"{userAsFriend.LastName} уже в друзьях");
                        return;
                    }
                    Program.friendService.Append(user, userAsFriend);
                    InfoMessage.Show("Пользователь " + userAsFriend.FirstName + " " +
                                     userAsFriend.LastName + " " + "добавлен к вам в друзья");
                    break;
                }
            case 2: // exclude existing friend
                {
                    Console.WriteLine("Укажите адрес электронной почты пользователя сети");
                    User userAsFriend = Program.userService.FindByEmail(Console.ReadLine());
                    int id = Program.friendService.FindSingleFriend(user, userAsFriend);

                    // if friend exist yet => delete friend
                    if (id != 0)
                    {
                        Program.friendService.Delete(id);
                        InfoMessage.Show("Пользователь " + userAsFriend.FirstName + " " +
                                         userAsFriend.LastName + " " + "исключен из списка друзей");
                    }
                    else
                    {
                        InfoMessage.Show("Пользователь " + userAsFriend.FirstName + " " +
                                         userAsFriend.LastName + " " + "не найден в списке друзей");
                    }
                    break;
                }
        }
    }
}
