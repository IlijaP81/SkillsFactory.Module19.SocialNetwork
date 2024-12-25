using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Services;

public class UserService
{
    IUserRepository userRepository;
    public UserService()
    {
        userRepository = new UserRepository();
    }

    /// <summary>
    /// Register new user
    /// </summary>
    /// <param name="userRegistrationData"></param>
    /// <exception cref="WrongPasswordException"></exception>
    /// <exception cref="InvalidEmailFormatException"></exception>
    /// <exception cref="EmailAllreadyExistException"></exception>
    /// <exception cref="Exception"></exception>
    public void Register(UserRegistrationData userRegistrationData)
    {
        // check for not-null user's data input
        if (String.IsNullOrEmpty(userRegistrationData.FirstName) &
            String.IsNullOrEmpty(userRegistrationData.LastName) &
            String.IsNullOrEmpty(userRegistrationData.Email) &
            String.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException("Данные должны быть заполнены");

        // check for password length
        if (userRegistrationData.Password.Length < 8)
            throw new WrongPasswordException();

        // check for email valid format
        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new InvalidEmailFormatException();

        // check for existing email
        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new EmailAllreadyExistException();

        UserEntity userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            email = userRegistrationData.Email,
            password = userRegistrationData.Password,
        };

        if (userRepository.Create(userEntity) == 0) throw new Exception();
    }

    /// <summary>
    /// Authenticates existing user
    /// </summary>
    /// <param name="userAuthenticationData"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="WrongPasswordException"></exception>
    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var userEntity = userRepository.FindByEmail(userAuthenticationData.Email);

        // check for user exists
        if (userEntity is null) throw new UserNotFoundException();

        // check for user's password is valid
        if (userEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(userEntity);
    }

    /// <summary>
    /// Show all network users on console
    /// </summary>
    public void ShowAllUsers()
    {
        List<UserEntity> usersEntities = userRepository.FindAll().ToList();
        InfoMessage.Show("В социальной сети зарегистрированы следующие пользователи: ");
        foreach (UserEntity userEntity in usersEntities)
        {
            InfoMessage.Show($"{userEntity.firstname} {userEntity.lastname} {userEntity.email}");
        }
    }

    /// <summary>
    /// Finds existing user by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    public User FindByEmail(string email)
    {
        var userEntity = userRepository.FindByEmail(email);

        // check for user exists 
        if (userEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(userEntity);
    }

    /// <summary>
    /// Finds existing user by id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    public User FindById(int Id)
    {
        var userEntity = userRepository.FindById(Id);

        // check for user exists 
        if (userEntity is null) throw new UserNotFoundException();

        return ConstructUserModel(userEntity);
    }

    /// <summary>
    /// Update user's data
    /// </summary>
    /// <param name="user"></param>
    /// <exception cref="Exception"></exception>
    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favorite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };

        if (this.userRepository.Update(updatableUserEntity) == 0)
            throw new Exception();
    }

    /// <summary>
    /// Delete user, friends, messages by UserId. 
    /// </summary>
    /// <param name="id"></param>
    public int Delete(int id)
    {
        return userRepository.DeleteById(id);
    }
    private User ConstructUserModel(UserEntity userEntity)
    {
        return new User(userEntity.id,
                      userEntity.firstname,
                      userEntity.lastname,
                      userEntity.password,
                      userEntity.email,
                      userEntity.photo,
                      userEntity.favorite_movie,
                      userEntity.favorite_book);
    }
}
