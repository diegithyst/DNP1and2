using Application.DaoInterfaces;
using Domain.Dtos;
using Domain.Models;

namespace FileData.DAOs;

public class PageFileDao : IPageDao
{
    private readonly FileContext context;

    public PageFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Page> CreateAsync(Page page)
    {
        int id = 1;
        if (context.Pages.Any())
        {
            id = context.Pages.Max(p => p.Id);
            id++;
        }

        page.Id = id;
        context.Pages.Add(page);
        context.SaveChanges();

        return Task.FromResult(page);
    }

    public Task<IEnumerable<Page>> GetAsync(PageSearchDto dto)
    {
        IEnumerable<Page> pages = context.Pages.AsEnumerable();
        if (dto.Id != null)
        {
            pages = context.Pages.Where(p => p.Id == dto.Id);
        }
        return Task.FromResult(pages);
    }
}
    