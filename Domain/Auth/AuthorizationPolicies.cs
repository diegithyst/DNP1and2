using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

namespace Domain.Auth;

public class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
        });
    }
}
