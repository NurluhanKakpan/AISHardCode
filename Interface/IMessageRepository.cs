using techTask2.Models;

namespace techTask2.Interface;

public interface IMessageRepository
{
    IEnumerable<Message> GetMessages(int ownerId);
    bool CreateMessage(Message message);
    bool Save();
}