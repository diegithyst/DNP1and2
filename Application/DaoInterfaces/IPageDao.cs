using Domain.Dtos;
using Domain.Models;

namespace Application.DaoInterfaces;

public interface IPageDao
{
    Task<Page> CreateAsync(Page page);
    Task<IEnumerable<Page>> GetAsync(PageSearchDto dto);

    Task<Page> GetByIdAsync(int id);
}