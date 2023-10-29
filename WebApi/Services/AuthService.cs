using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Dtos;
using Domain.Models;
using FileData;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserLogic userLogic;

    public AuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    public async Task<User> GetUser(string username, string password)
    {
        IEnumerable<User> users = await userLogic.GetAsync();
        User existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));;
        Console.WriteLine("This was called");

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }
        
        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public Task RegisterUser(UserCreationDto user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new Exception("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new Exception("Password cannot be null");
        }

        if (string.IsNullOrEmpty(user.Email))
        {
            throw new Exception("Email cannot be empty");
        }
        
        userLogic.CreateAsync(user);
        return Task.CompletedTask;
    }
}