using System.Text.RegularExpressions;
using AutoMapper;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Service;

public class InspectorService : IInspectorService
{
    private readonly IInspectorRepository _inspectorRepository;
    private readonly IMapper _mapper;

    public InspectorService(IInspectorRepository inspectorRepository, IMapper mapper)
    {
        _inspectorRepository = inspectorRepository;
        _mapper = mapper;
    }
    public IEnumerable<InspectorDto> GetInspectors()
    {
        var inspectors = _inspectorRepository.GetInspectors();
        var result = _mapper.Map<IEnumerable<InspectorDto>>(inspectors);
        return result;
    }

    public InspectorDto GetInspector(int inspectorId)
    {
        var inspector = _inspectorRepository.GetInspector(inspectorId);
        var result = _mapper.Map<InspectorDto>(inspector);
        return result;
    }

    public bool CheckInspectorDto(InspectorCreateDto? inspectorDto)
    {
        return inspectorDto != null;
    }

    public bool CheckInspectorWithSameIin(InspectorCreateDto? inspectorDto)
    {
        var inspector = _inspectorRepository.GetInspectors().FirstOrDefault(i => i.Iin == inspectorDto!.Iin);
        return inspector == null;

    }

    public bool CheckInspectorInputIin(string iinPattern,InspectorCreateDto? inspectorDto)
    {
        return inspectorDto == null || Regex.IsMatch(inspectorDto.Iin!,iinPattern);
    }

    public bool CreateInspector(InspectorCreateDto? inspectorDto)
    {
        var inspectorMap = _mapper.Map<Inspector>(inspectorDto);
        if (inspectorDto != null) inspectorMap.FullName = inspectorDto.FirstName + ' ' + inspectorDto.LastName;
        return _inspectorRepository.CreateInspector(inspectorMap); 
    }
}