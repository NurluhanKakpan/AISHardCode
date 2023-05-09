using AutoMapper;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Service;

public class SrtsService : ISrtsService
{
    private readonly IInspectorRepository _inspectorRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly ISrtsRepository _srtsRepository;
    private readonly ITransportRepository _transportRepository;
    private readonly IMapper _mapper;

    public SrtsService(IInspectorRepository inspectorRepository, IApplicationRepository applicationRepository,
        ISrtsRepository srtsRepository, ITransportRepository transportRepository, IMapper mapper)
    {
        _inspectorRepository = inspectorRepository;
        _applicationRepository = applicationRepository;
        _srtsRepository = srtsRepository;
        _transportRepository = transportRepository;
        _mapper = mapper;
    }
    
    public IEnumerable<SrtsDto> GetSrtses()
    {
        var srtses = _srtsRepository.GetSrtses();
        var result = _mapper.Map<IEnumerable<SrtsDto>>(srtses);
        return result;
    }

    public SrtsDto GetSrts(int srtsId)
    {
        var srts = _srtsRepository.GetSrts(srtsId);
        var result = _mapper.Map<SrtsDto>(srts);
        return result;
    }

    public bool CheckInspectorAndApplication(int inspectorId, int appId)
    {
        var inspector = _inspectorRepository.GetInspector(inspectorId);
        if (inspector == null)
        {
            return false;
        }
        var applicationId = _applicationRepository.GetApplications().Where(a => a.OwnerRegion == inspector.Region && a.InProcess).Min(e => e.Id);
        if (applicationId != appId)
        {
            return false;
        }

        return true;
    }

    public bool CreateSrts(int inspectorId, int appId)
    {
        var app = _applicationRepository.GetApplications().FirstOrDefault(a => a.Id == appId);
                app!.AppStatus = "process finished";
                app.InProcess = false;
                app.IsAccept = true;
                
                var transportId = app.TransportId;
                var transport = _transportRepository.GetTransport(transportId);
                transport!.HaveSrts = true;
                
                var note = app.AppType != "Registration";
                var random = new Random();
                var digits = "";
        
                for (int i = 0; i < 8; i++) {
                        int digit = random.Next(0, 10);
                        digits += digit.ToString();
                }
                var letters = "";
        
                for (var i = 0; i < 2; i++) {
                        var ascii = random.Next(65, 91);
                        var letter = (char)ascii;
                        letters += letter.ToString();
                }

                var srtsFromDb = _srtsRepository.GetSrtses().FirstOrDefault(s => s.TransportVin == transport.Vin);
                if (app.AppType == "Registration" && srtsFromDb == null)
                {
                        var srts = new Srts
                        { 
                                OwnerId = app.OwnerId,
                                TransportId = app.TransportId,
                                OwnerFullName = app.OwnerFullName,
                                OwnerIin = app.OwnerIin,
                                OwnerRegion = app.OwnerRegion,
                                TransportGrnz = app.TransportGrnz,
                                TransportVin = app.TransportVin,
                                TransportCategory = app.TransportCategory,
                                TransportMarca = app.TransportMarca,
                                Sign = note,
                                SrtsNumber = letters + digits
                        };
                
                        if (!_srtsRepository.CreateSrts(srts))
                        {
                             return false;
                        }
                }

                if (app.AppType == "Registration" && srtsFromDb != null)
                {
                    srtsFromDb.Sign = false;
                    if (!_srtsRepository.UpdateSrts(srtsFromDb))
                    {
                        return false;
                    }
                }
                if (app.AppType == "De-Registration")
                {
                        var transportFromSrts = _srtsRepository.GetSrtses()
                                .FirstOrDefault(s => s.TransportId == transportId);
                        transportFromSrts!.Sign = true;
                        if (!_srtsRepository.UpdateSrts(transportFromSrts))
                        {
                                return false;
                        }
                }

                return true;
    }
}