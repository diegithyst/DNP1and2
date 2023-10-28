namespace Domain.Dtos;

public class PageSearchDto
{
    public int? Id { get; }
    
    public PageSearchDto(int? id)
    {
        Id = id;
    }
}