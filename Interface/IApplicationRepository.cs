using techTask2.Models;

namespace techTask2.Interface;

public interface IApplicationRepository
{
    IEnumerable<Application> GetApplications();
    ICollection<Application> GetApplicationsByOwnerId(int ownerId);
    bool CreateApplication(Application application);
    bool Save();
    bool UpdateApplication(Application application);
}