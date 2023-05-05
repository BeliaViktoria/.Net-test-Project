namespace BLL.Interfaces;

using DAL.Models;

public interface IUserService
{
    User? GetUserById(int id);

    int AuthorizeUser(string login, string password);

    int RegisterUser(User user);

    void UpdateUser(User user);

    void DeleteUser(User user);
}
