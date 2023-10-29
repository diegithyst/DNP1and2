using Domain.Dtos;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IUserLogic
{
    Task<User> CreateAsync(UserCreationDto userToCreate);

    Task<IEnumerable<User>> GetAsync();
    Task<User?> GetByUsernameAsync(string username);
}