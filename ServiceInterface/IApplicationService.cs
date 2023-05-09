using techTask2.Data;
using techTask2.Dto;
using techTask2.Models;

namespace techTask2.ServiceInterface;

public interface IApplicationService
{

    IEnumerable<ApplicationDto> GetApplications();
    ApplicationDto GetApplication(int inspectorId);
    bool CheckApplication(ApplicationCreateDto? applicationDto);
    bool CheckOwner(int ownerId,ApplicationCreateDto? applicationDto);
    bool CheckTransportInformation(ApplicationCreateDto? applicationDto);
    bool CheckApplicationFromDb(ApplicationCreateDto? applicationDto);
    bool CheckApplicationType(ApplicationCreateDto? applicationDto);
    bool CheckApplicationTypeWithSrts(ApplicationCreateDto? applicationDto);
    bool CheckTransportFromDb(int ownerId,ApplicationCreateDto? applicationDto);
    bool CreateApplicationAndTransport(int ownerId,ApplicationCreateDto? applicationDto);
    bool CancelApplication( int inspectorId , int applicationId);

}