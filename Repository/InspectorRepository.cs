using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class InspectorRepository : IInspectorRepository
{
    private readonly DataContext _context;

    public InspectorRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<Inspector> GetInspectors()
    {
        return _context.Inspectors.ToList();
    }

    public Inspector? GetInspector(int inspectorId)
    {
        return _context.Inspectors.FirstOrDefault(i => i.Id == inspectorId);
    }

    public bool CreateInspector(Inspector inspector)
    {
        _context.Inspectors.Add(inspector);
        return Save();
    }

    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}