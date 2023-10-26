namespace Domain.Dtos;

public class PageCreationDto
{
    public int CreatorId { get; }
    public string Title { get; }
    public string Body { get; }

    public PageCreationDto(int creatorId, string title, string body)
    {
        CreatorId = creatorId;
        Title = title;
        Body = body;
    }
}