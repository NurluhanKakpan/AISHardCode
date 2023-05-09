using AutoMapper;
using techTask2.Data;
using techTask2.Dto;
using techTask2.Models;

namespace techTask2.Helper;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Owner, OwnerDto>();
        CreateMap<OwnerCreateDto, Owner>();
        CreateMap<Transport, TransportDto>();
        CreateMap<ApplicationCreateDto, Application>();
        CreateMap<Application, ApplicationDto>();
        CreateMap<Inspector, InspectorDto>();
        CreateMap<InspectorCreateDto, Inspector>();
        CreateMap<Srts, SrtsDto>();
        CreateMap<SrtsCreateDto, Srts>();
        CreateMap<Message, MessageDto>();
        CreateMap<MessageCreateDto, Message>();
    }
}