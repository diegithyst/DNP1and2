using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly DataContext context;

    public UserEfcDao(DataContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        return existing;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(email.ToLower()));
        return existing;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        IQueryable<User> usersQuery = context.Users.AsQueryable();
        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        User? user = await context.Users.FindAsync(id);
        return user;
    }
}