namespace DAL.Interfaces;

using global::DAL.Models;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers();
    User? GetUserById(int id);

    void CreateUser(User user);

    void UpdateUser(User user);

    void DeleteUser(User user);
}
