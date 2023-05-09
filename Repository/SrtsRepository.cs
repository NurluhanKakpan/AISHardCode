using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class SrtsRepository: ISrtsRepository
{
    private readonly DataContext _context;

    public SrtsRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<Srts> GetSrtses()
    {
        return _context.Srts.ToList();
    }

    public Srts GetSrts(int srtsId)
    {
        return _context.Srts.FirstOrDefault(s => s.Id == srtsId)!;
    }

    public bool CreateSrts(Srts srts)
    {
        _context.Srts.Add(srts);
        return Save();
    }

    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }

    public bool UpdateSrts(Srts srts)
    {
        _context.Srts.Update(srts);
        return Save();
    }
}