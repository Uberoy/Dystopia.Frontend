namespace Dystopia.Frontend.Entities;

public class Ticket
{
    public string UserId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
}