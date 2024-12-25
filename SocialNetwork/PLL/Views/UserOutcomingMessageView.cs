using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class UserOutcomingMessageView
{
    /// <summary>
    /// Returns number of outcoming messages. 
    /// Optionally write all outcoming messages to console if non-mandatory parameter mode != 0. 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public int Show(User user, int mode = 0)
    {
        List<Message> messages = new List<Message>();
        try
        {
            messages = Program.messageService.GetOutcomingMessagesByUserId(user.Id).ToList();
            if (mode != 0) // list of outcoming messages is required to be shown on console
            {
                if (messages.Count() == 0)
                {
                    InfoMessage.Show("Исходящих сообщений не найдено"); return 0;
                }
                foreach (var message in messages)
                {
                    InfoMessage.Show("Исходящее сообщение номер " + message.Id + " к " + message.RecipientEmail +
                                     " Текст сообщения " + message.Content);
                }
            }
        }
        catch (Exception ex)
        {
            AlertMessage.Show("Произошла ошибка " + ex.Message);
        }
        return messages.Count;
    }
}
