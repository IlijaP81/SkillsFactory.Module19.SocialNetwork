using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class MessageDeletingView
{
    /// <summary>
    /// Provides dialog with user to delete message
    /// </summary>
    public void Show(User user)
    {
        InfoMessage.Show("У вас есть следующие сообщения: ");
        Program.userIncomingMessageView.Show(user, 1);
        Program.userOutcomingMessageView.Show(user, 1);
        Console.WriteLine("Укажите номер сообщения, которое необходимо удалить");
        int.TryParse(Console.ReadLine(), out int msgNumber);
        try
        {
            Program.messageService.Delete(msgNumber);
            SuccessMessage.Show("Сообщение " + msgNumber + "удалено");
        }
        catch (Exception ex)
        { 
            AlertMessage.Show("Произошла ошибка " + ex.Message);
        }
    }
}
