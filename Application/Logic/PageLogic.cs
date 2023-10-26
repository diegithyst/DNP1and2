using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.Dtos;
using Domain.Models;

namespace Application.Logic;

public class PageLogic : IPageLogic
{
    private readonly IPageDao pageDao;
    private readonly IUserDao userDao;

    public PageLogic(IPageDao pageDao, IUserDao userDao)
    {
        this.pageDao = pageDao;
        this.userDao = userDao;
    }
    
    public async Task<Page> CreateAsync(PageCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.CreatorId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.CreatorId} was not found");
        }

        ValidateData(dto);
        Page page = new Page(user, dto.Title, dto.Body);
        Page created = await pageDao.CreateAsync(page);
        return created;
    }

    public Task<IEnumerable<Page>> GetAsync(PageSearchDto dto)
    {
        return pageDao.GetAsync(dto);
    }

    private static void ValidateData(PageCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty");
    }
}