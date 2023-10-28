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

    public Task<IEnumerable<Page>> GetAsync()
    {
        IEnumerable<Page> pages = context.Pages.AsEnumerable();
        return Task.FromResult(pages);
    }

    public Task<Page> GetByIdAsync(int id)
    {
        Page existing = context.Pages.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(existing);
    }
}
    