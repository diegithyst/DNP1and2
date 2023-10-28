using Domain.Models;

namespace Domain.Dtos;

public class BasicIdPage
{
    public int Id { get; }
    public User Creator { get; }
    public string Title { get; }
    public string Body { get; }

    public BasicIdPage(int id, User creator, string title, string body)
    {
        Id = id;
        Creator = creator;
        Title = title;
        Body = body;
    }
}