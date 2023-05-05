namespace DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;

public class UserRepository : IUserRepository
{
    private readonly TestDbContext context;

    public UserRepository(TestDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<User> GetAllUsers()
    {
        return this.context.Users?.ToList() ?? Enumerable.Empty<User>();
    }

    public User? GetUserById(int id)
    {
        return this.context.Users?.Single(u => u.UserID == id);
    }

    public void CreateUser(User user)
    {
        this.context.Users?.Add(user);
        this.context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        this.context.Users?.Update(user);
        this.context.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        this.context.Users?.Remove(user);
        this.context.SaveChanges();
    }
}
