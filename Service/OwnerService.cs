using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Service;

public class OwnerService : IOwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;

    public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
    {
        _ownerRepository = ownerRepository;
        _mapper = mapper;
    }
    public IEnumerable<OwnerDto> GetOwners()
    {
        var owners = _ownerRepository.GetOwners();
        var result = _mapper.Map<IEnumerable<OwnerDto>>(owners);
        return result;
    }

    public OwnerDto GetOwner(int ownerId)
    {
        var owner = _ownerRepository.GetOwner(ownerId);
        var result = _mapper.Map<OwnerDto>(owner);
        return result;
    }

    public bool CheckOwnerDto(OwnerCreateDto? ownerDto)
    {
        return ownerDto != null;
    }

    public bool CheckOwnerExistsWithSameIin(OwnerCreateDto? ownerDto)
    {
        var owner = _ownerRepository.GetOwners().FirstOrDefault(o => o.Iin == ownerDto!.Iin);
        return owner == null;
    }

    public bool CheckOwnerInputIin(string iinPattern,OwnerCreateDto? ownerDto)
    {
        return ownerDto == null || Regex.IsMatch(ownerDto.Iin!,iinPattern);
    }

    public bool CreateOwner(OwnerCreateDto? ownerDto)
    {
        var ownerMap = _mapper.Map<Owner>(ownerDto);
        if (ownerDto != null) ownerMap.FullName = ownerDto.FirstName + ' ' + ownerDto.LastName;
        return _ownerRepository.CreateOwner(ownerMap);
    }
}