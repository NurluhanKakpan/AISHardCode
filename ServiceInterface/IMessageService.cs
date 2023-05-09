using techTask2.Dto;
using techTask2.Models;

namespace techTask2.ServiceInterface;

public interface IMessageService
{
    IEnumerable<MessageDto>? GetMessages(int ownerId);
    bool CreateMessage(int applicationId,MessageCreateDto messageDto);
}