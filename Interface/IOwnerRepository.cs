using techTask2.Models;

namespace techTask2.Interface;

public interface IOwnerRepository
{
    ICollection<Owner> GetOwners();
    Owner? GetOwner(int ownerId);
    bool CreateOwner(Owner owner);
    bool UpdateOwner(Owner owner);
    bool Save();
}