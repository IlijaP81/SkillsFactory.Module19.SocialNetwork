using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class UserIncomingMessageView
{
    /// <summary>
    /// Returns number of incoming messages. 
    /// Optionally write all incoming messages to console if non-mandatory parameter mode != 0. 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    public int Show(User user, int mode = 0)
    {
        List <Message> messages = new List<Message>();
        try
        {
            messages = Program.messageService.GetIncomingMessagesByUserId(user.Id).ToList();
            if (mode != 0) // list of incoming messages is required to be shown on console
            {
                if (messages.Count() == 0)
                {
                    InfoMessage.Show("Входящих сообщений не найдено"); return 0;
                }

                foreach (var message in messages)
                {
                    InfoMessage.Show("Входящее сообщение номер " + message.Id + " от " + message.SenderEmail +
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
