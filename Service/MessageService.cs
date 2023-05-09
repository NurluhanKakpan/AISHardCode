using AutoMapper;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Service;

public class MessageService :IMessageService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMessageRepository _messageRepository;
    private readonly IMapper _mapper;
    private readonly IApplicationRepository _applicationRepository;

    public MessageService(IMessageRepository messageRepository, IOwnerRepository ownerRepository, IMapper mapper,IApplicationRepository applicationRepository)
    {
        _ownerRepository = ownerRepository;
        _messageRepository = messageRepository;
        _mapper = mapper;
        _applicationRepository = applicationRepository;
    }
    public IEnumerable<MessageDto>? GetMessages(int ownerId)
    {
        var owner = _ownerRepository.GetOwner(ownerId);
        if (owner == null)
        { 
            throw new Exception("Owner not found");
        }
        var messages = _messageRepository.GetMessages(ownerId);
        var result = _mapper.Map<IEnumerable<MessageDto>>(messages);
        return result;

    }
    
    public bool CreateMessage(int applicationId,MessageCreateDto messageDto)
    {
        if (messageDto == null)
        {
            throw new Exception("message cannot be a null");
        }

        var app = _applicationRepository.GetApplications().FirstOrDefault(a => a.Id == applicationId);
        if (app == null)
        {
            throw new Exception("Application not found");
        }
        var ownerId = app!.OwnerId;
        var messageMap = _mapper.Map<Message>(messageDto);
        messageMap.OwnerId = ownerId;
        messageMap.MessageTime = DateTime.Now.ToUniversalTime();
        return _messageRepository.CreateMessage(messageMap);
    }
}