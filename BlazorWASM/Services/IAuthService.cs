using System.Security.Claims;
using Domain.Dtos;
using Domain.Models;

namespace BlazorWASM.Services;

public interface IAuthService
{
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task RegisterAsync(UserCreationDto user);
    public Task<ClaimsPrincipal> GetAuthAsync();
    
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}