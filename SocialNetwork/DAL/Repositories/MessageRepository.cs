using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        /// <summary>
        /// Creates new message
        /// </summary>
        /// <param name="messageEntity"></param>
        /// <returns></returns>
        public int Create(MessageEntity messageEntity)
        {
            return Execute(@"insert into messages(content, sender_id, recipient_id) 
                             values(:content,:sender_id,:recipient_id)", messageEntity);
        }

        /// <summary>
        ///  Find message by sender Id
        /// </summary>
        /// <param name="senderId"></param>
        /// <returns></returns>
        public IEnumerable<MessageEntity> FindBySenderId(int senderId)
        {
            return Query<MessageEntity>("select * from messages where sender_id = :sender_id", new { sender_id = senderId });
        }

        /// <summary>
        /// Find message by recipient Id
        /// </summary>
        /// <param name="recipientId"></param>
        /// <returns></returns>
        public IEnumerable<MessageEntity> FindByRecipientId(int recipientId)
        {
            return Query<MessageEntity>("select * from messages where recipient_id = :recipient_id", new { recipient_id = recipientId });
        }

        /// <summary>
        /// Delete message by message Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public int DeleteById(int messageId)
        {
            return Execute("delete from messages where id = :id", new { id = messageId });
        }

    }

    public interface IMessageRepository
    {
        int Create(MessageEntity messageEntity);
        IEnumerable<MessageEntity> FindBySenderId(int senderId);
        IEnumerable<MessageEntity> FindByRecipientId(int recipientId);
        int DeleteById(int messageId);
    }
}