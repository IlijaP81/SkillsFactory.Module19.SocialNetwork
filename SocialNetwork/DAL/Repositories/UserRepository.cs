using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.DAL.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into users (firstname,lastname,password,email) 
                             values (:firstname,:lastname,:password,:email)", userEntity);
        }

        /// <summary>
        /// Returns all users of network
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        /// <summary>
        /// Finds user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }

        /// <summary>
        /// Finds user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        /// <summary>
        /// Update user's data
        /// </summary>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, password = :password, email = :email,
                             photo = :photo, favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id", userEntity);
        }

        /// <summary>
        /// Synchronous deletion all entries concerning the user from various DB tables
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(int id)
        {
            int i = 0;
            try
            {   
                Execute("delete from users where id = :id_p", new { id_p = id });
                Execute("delete from friends where user_id = :id_p", new { id_p = id });
                Execute("delete from friends where friend_id = :id_p", new { id_p = id });
                Execute("delete from messages where sender_id = :id_p", new { id_p = id });
                Execute("delete from messages where recipient_id = :id_p", new { id_p = id });
                i = 1;
            }
            catch (Exception ex)
            {
                AlertMessage.Show("Произошла ошибка " + ex.Message);
            }
            return i;
        }
    }

    public interface IUserRepository
    {
        int Create(UserEntity userEntity);
        UserEntity FindByEmail(string email);
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(int id);
        int Update(UserEntity userEntity);
        int DeleteById(int id);
    }
}