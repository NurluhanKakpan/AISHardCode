using techTask2.Dto;
using techTask2.Models;

namespace techTask2.ServiceInterface;

public interface IInspectorService
{
    IEnumerable<InspectorDto> GetInspectors();
    InspectorDto GetInspector(int inspectorId);
    bool CheckInspectorDto(InspectorCreateDto? inspectorDto);
    bool CheckInspectorWithSameIin(InspectorCreateDto? inspectorDto);
    bool CheckInspectorInputIin(string iinPattern,InspectorCreateDto? inspectorDto);
    bool CreateInspector(InspectorCreateDto? inspectorDto);
}