using Domain.Dtos;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPageService
{
    Task CreateAsync(PageCreationDto dto);
    
    Task<ICollection<Page>> GetAsync();

    Task<BasicIdPage> GetByIdAsync(int id);
}