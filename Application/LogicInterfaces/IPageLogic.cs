using Domain.Dtos;
using Domain.Models;

namespace Application.LogicInterfaces;

public interface IPageLogic
{
    Task<Page> CreateAsync(PageCreationDto dto);
    Task<IEnumerable<Page>> GetAsync(PageSearchDto dto);

    Task<BasicIdPage> GetByIdAsync(int id);
}