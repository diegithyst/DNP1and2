using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Dtos;
using Domain.Models;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto dto)
    {
        User? existingUsername = await userDao.GetByUsernameAsync(dto.Username);
        User? existingEmail = await userDao.GetByUsernameAsync(dto.Email);
        if (existingUsername != null)
        {
            throw new Exception("Username already taken!");
        }
        if (existingEmail != null)
        {
            throw new Exception("User with this email already exists");
        }
        
        ValidateData(dto);
        User toCreate = new User
        {
            Username = dto.Username,
            Password = dto.Password,
            Email = dto.Email
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        IEnumerable<User> users = await userDao.GetAsync();
        return users;
    }

    public Task<User?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }


    private static void ValidateData(UserCreationDto dto)
    {
        string username = dto.Username;
        string password = dto.Password;

        if (username.Length < 3)
        {
            throw new Exception("Username must be at least 3 characters!");
        }

        if (password.Length < 5)
        {
            throw new Exception("Password must be at least 5 characters!");
        }
    }
}