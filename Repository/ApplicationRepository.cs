using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class ApplicationRepository:IApplicationRepository
{
    private readonly DataContext _context;


    public ApplicationRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Application> GetApplications()
    {
        return _context.Applications!.ToList();
    }

    public ICollection<Application> GetApplicationsByOperatorId(int operatorId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Application> GetApplicationsByOwnerId(int ownerId)
    {
        throw new NotImplementedException();
    }

    public bool CreateApplication(Application application)
    {
        _context.Applications!.Add(application);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateApplication(Application application)
    {
        _context.Applications?.Update(application);
        return Save();
    }
}