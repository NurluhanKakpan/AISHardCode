using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class MessageRepository :IMessageRepository
{
    private readonly DataContext _context;

    public MessageRepository(DataContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Message> GetMessages(int ownerId)
    {
        return _context.Messages.Where(m => m.OwnerId == ownerId).ToList();
    }

    public bool CreateMessage(Message message)
    {
        _context.Messages.Add(message);
        return Save();
    }

    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}