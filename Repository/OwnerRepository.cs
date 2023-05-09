using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class OwnerRepository : IOwnerRepository
{
    private readonly DataContext _context;

    public OwnerRepository(DataContext context)
    {
        _context = context;
    }
    public ICollection<Owner> GetOwners()
    {
        return _context.Owners!.ToList();
    }

    public Owner? GetOwner(int ownerId)
    {
        return _context.Owners!.FirstOrDefault(o=>o.Id == ownerId);
    }

    public bool CreateOwner(Owner owner)
    {
        _context.Owners!.Add(owner);
        return Save();
    }

    public bool UpdateOwner(Owner owner)
    {
        _context.Update(owner);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}