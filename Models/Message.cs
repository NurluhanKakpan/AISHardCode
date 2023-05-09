namespace techTask2.Models;

public class Message
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string? MessageForOwner { get; set; }
    public DateTime MessageTime { get; set; }
    public Owner? Owner { get; set; }
}