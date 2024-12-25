using SocialNetwork.DAL.Entities;

namespace SocialNetwork.DAL.Repositories;

public class FriendRepository : BaseRepository, IFriendRepository
{
    /// <summary>
    /// Return all friends for user by user's Id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IEnumerable<FriendEntity> FindAllByUserId(int userId)
    {
        return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
    }

    /// <summary>
    /// Returns single friend for specified user by user's id
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="friendId"></param>
    /// <returns></returns>
    public FriendEntity FindSingleByUserIdAndFriendId(int userId, int friendId)
    {
        return QueryFirstOrDefault<FriendEntity>(@"select * from friends 
                                                 where user_id = :user_id  
                                                 and friend_id = :friend_id",
                                                 new { user_id = userId, friend_id = friendId });
    }

    /// <summary>
    /// Appends new friend
    /// </summary>
    /// <param name="friendEntity"></param>
    /// <returns></returns>
    public int Create(FriendEntity friendEntity)
    {
        return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
    }

    /// <summary>
    /// Deletes friend for user
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public int Delete(int id)
    {
        return Execute(@"delete from friends where id = :id_p", new { id_p = id });
    }
}

public interface IFriendRepository
{
    int Create(FriendEntity friendEntity);
    IEnumerable<FriendEntity> FindAllByUserId(int userId);
    FriendEntity FindSingleByUserIdAndFriendId(int userId, int friendId);
    int Delete(int id);
}