using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.BLL.Models;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services;

public class MessageService
{
    IMessageRepository messageRepository;
    IUserRepository userRepository;
    public MessageService()
    {
        messageRepository = new MessageRepository();
        userRepository = new UserRepository();
    }

    /// <summary>
    /// Return all incoming messages for user by recipient's id
    /// </summary>
    /// <param name="recipientId"></param>
    /// <returns></returns>
    public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
    {
        var messages = new List<Message>();
        messageRepository.FindByRecipientId(recipientId).ToList().ForEach(message =>
        {
            var senderUserEntity = userRepository.FindById(message.sender_id);
            var recipientUserEntity = userRepository.FindById(message.recipient_id);
            messages.Add(new Message(message.id, message.content, senderUserEntity.email, recipientUserEntity.email));
        });
        return messages;
    }

    /// <summary>
    /// /// Return all outcoming messages for user by sender's id
    /// </summary>
    /// <param name="senderId"></param>
    /// <returns></returns>
    public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
    {
        var messages = new List<Message>();
        messageRepository.FindBySenderId(senderId).ToList().ForEach(message =>
        {
            var senderUserEntity = userRepository.FindById(message.sender_id);
            var recipientUserEntity = userRepository.FindById(message.recipient_id);
            messages.Add(new Message(message.id, message.content, senderUserEntity.email, recipientUserEntity.email));
        });
        return messages;
    }

    /// <summary>
    /// Provides check for message sending data. Send message from sender to recipient.
    /// </summary>
    /// <param name="messageSendingData"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    public void SendMessage(MessageSendingData messageSendingData)
    {
        // MessageSendingData: Content, RecipientEmail, SenderId

        // check for email format is valid
        if (!new EmailAddressAttribute().IsValid(messageSendingData.RecipientEmail))
            throw new InvalidEmailFormatException();

        // check for message content is not empty
        if (String.IsNullOrEmpty(messageSendingData.Content)) throw new ArgumentNullException();

        // check for message content length is not above limit
        if (messageSendingData.Content.Length > 5000) throw new ArgumentOutOfRangeException();

        // find recipient by its mail
        var userEntity = userRepository.FindByEmail(messageSendingData.RecipientEmail);
        if (userEntity is null) throw new UserNotFoundException();

        // compile obligatory message attributes
        var messageEntity = new MessageEntity
        {
            content = messageSendingData.Content,
            sender_id = messageSendingData.SenderId,
            recipient_id = userEntity.id
        };

        // call appropriate repository method
        if (messageRepository.Create(messageEntity) == 0) throw new Exception();
    }
    
    /// <summary>
    /// Deletes message by Id
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        messageRepository.DeleteById(id);
    }
}
