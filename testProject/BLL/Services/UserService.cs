namespace BLL.Services;

using DAL.Interfaces;
using DAL.Models;
using System;
using global::BLL.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public User? GetUserById(int id)
    {
        return this.userRepository.GetUserById(id);
    }

    public int AuthorizeUser(string login, string password)
    {
        return this.userRepository.GetAllUsers().Single(u => u.Login == login && u.Password == password).UserID;
    }

    public int RegisterUser(User user)
    {
        this.userRepository.CreateUser(user);
        return user.UserID;
    }

    public void UpdateUser(User user)
    {
        this.userRepository.UpdateUser(user);
    }

    public void DeleteUser(User user)
    {
        this.userRepository.DeleteUser(user);
    }
}
