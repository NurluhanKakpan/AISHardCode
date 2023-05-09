using Microsoft.AspNetCore.Mvc;
using techTask2.Dto;
using techTask2.Models;

namespace techTask2.ServiceInterface;

public interface IOwnerService
{
    IEnumerable<OwnerDto> GetOwners();
    OwnerDto GetOwner(int ownerId);

   bool CheckOwnerDto(OwnerCreateDto? ownerDto);
    bool CheckOwnerExistsWithSameIin(OwnerCreateDto? ownerDto);
    bool CheckOwnerInputIin(string iinPattern,OwnerCreateDto? ownerDto);
    bool CreateOwner(OwnerCreateDto? ownerDto);


}