using Application.LogicInterfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PageController : ControllerBase
{
    private readonly IPageLogic pageLogic;

    public PageController(IPageLogic pageLogic)
    {
        this.pageLogic = pageLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Page>> CreateAsync(PageCreationDto dto)
    {
        try
        {
            Page page = await pageLogic.CreateAsync(dto);
            return Created($"/pages/{page.Id}", page);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Page>>> GetAsync([FromQuery] int? id)
    {
        try
        {
            PageSearchDto parameters = new(id);
            IEnumerable<Page> pages = await pageLogic.GetAsync(parameters);
            return Ok(pages);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}