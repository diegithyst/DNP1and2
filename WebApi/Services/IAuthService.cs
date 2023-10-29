using Domain.Dtos;
using Domain.Models;

namespace WebApi.Services;

public interface IAuthService
{
    Task<User> GetUser(string username, string password);
    Task RegisterUser(UserCreationDto user);
}