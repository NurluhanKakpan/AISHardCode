using techTask2.Dto;

namespace techTask2.ServiceInterface;

public interface ISrtsService
{

    IEnumerable<SrtsDto> GetSrtses();
    SrtsDto GetSrts(int srtsId);

    bool CheckInspectorAndApplication(int inspectorId, int appId);
    bool CreateSrts(int inspectorId, int appId);

}