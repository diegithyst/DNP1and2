using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Page
{
    public int Id { get; set; }
    public User Creator { get; set; }
    public int CreatorId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }


    public Page(User creator, string title, string body)
    {
        Creator = creator;
        Title = title;
        Body = body;
    }
    
    public Page(){}
}