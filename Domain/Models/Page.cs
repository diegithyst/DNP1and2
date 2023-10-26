namespace Domain.Models;

public class Page
{
    public int Id { get; set; }
    public User Creator { get; }
    public string Title { get; }
    public string Body { get; }


    public Page(User creator, string title, string body)
    {
        Creator = creator;
        Title = title;
        Body = body;
    }
}