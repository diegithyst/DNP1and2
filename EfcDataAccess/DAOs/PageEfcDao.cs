using Application.DaoInterfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PageEfcDao : IPageDao
{
    private readonly DataContext context;

    public PageEfcDao(DataContext context)
    {
        this.context = context;
    }
    public async Task<Page> CreateAsync(Page page)
    {
        EntityEntry<Page> added = await context.Pages.AddAsync(page);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<IEnumerable<Page>> GetAsync()
    {
        IQueryable<Page> query = context.Pages.Include(p => p.Creator).AsQueryable();
        List<Page> result = await query.ToListAsync();
        return result;
    }

    public async Task<Page> GetByIdAsync(int id)
    {
        Page? found = await context.Pages.Include(p => p.Creator).SingleOrDefaultAsync(p => p.Id == id);
        return found;
    }
}