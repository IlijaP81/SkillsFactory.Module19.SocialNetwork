using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views;

public class MessageSendingView
{
    MessageService messageService;

    public MessageSendingView(MessageService messageService)
    {
        this.messageService = messageService;
    }

    /// <summary>
    /// Provides dialog with user to collect message attributes.
    /// Begins sending message process.
    /// </summary>
    /// <param name="user"></param>
    public void Show(User user)
    {
        MessageSendingData messageSendingData = new MessageSendingData();
        Console.WriteLine("Введите адрес получателя: ");
        messageSendingData.RecipientEmail = Console.ReadLine();
        Console.WriteLine("Введите сообщение (не более 5000 символов): ");
        messageSendingData.Content = Console.ReadLine();
        messageSendingData.SenderId = user.Id;

        try
        {
            messageService.SendMessage(messageSendingData);
            SuccessMessage.Show("Сообщение успешно отправлено");
        }
        // other exceptions process in MessageService class
        catch (Exception ex)
        {
            AlertMessage.Show("Произошла ошибка" + ex.Message);
        }
    }
}
