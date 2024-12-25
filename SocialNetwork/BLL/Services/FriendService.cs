using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System.Collections.Generic;

namespace SocialNetwork.BLL.Services;
public class FriendService
{
    IFriendRepository friendRepository;
    FriendEntity friendEntity = new FriendEntity();

    public FriendService() 
    {
        friendRepository = new FriendRepository();
    }
    
    /// <summary>
    /// Returns all friends for user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public List<FriendEntity> FindAllFriends(User user)
    {
        List <FriendEntity> friends = new List<FriendEntity>();
        try
        {
            friends = friendRepository.FindAllByUserId(user.Id).ToList();
        }
        catch (Exception ex)
        { 
            AlertMessage.Show("Произошла ошибка " + ex.Message);
        }
        return friends;
    }

    /// <summary>
    /// Returns record's Id from db.friends for specified user and friend   
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userAsFriend"></param>
    /// <returns></returns>
    public int FindSingleFriend(User user, User userAsFriend)
    {
        FriendEntity friend = new FriendEntity();
        try
        {
            friend = friendRepository.FindSingleByUserIdAndFriendId(user.Id, userAsFriend.Id);
        }
        catch (Exception ex) 
        {
            AlertMessage.Show("Произошла ошибка " + ex.Message); 
        }
        return friend == null ? 0 : friend.id;
    }
    
    /// <summary>
    /// Appends new friend for user 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userAsFriend"></param>
    /// <exception cref="Exception"></exception>
    public void Append(User user, User userAsFriend)
    {
        friendEntity.user_id = user.Id;
        friendEntity.friend_id = userAsFriend.Id;
        if (friendRepository.Create(friendEntity) == 0) throw new Exception();
    }

    /// <summary>
    /// Delete existing friend for user
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="Exception"></exception>
    public void Delete(int id)
    {
        if (friendRepository.Delete(id) == 0) throw new Exception();
    }
}
