using System.Text.RegularExpressions;
using AutoMapper;
using techTask2.Data;
using techTask2.Dto;
using techTask2.Interface;
using techTask2.Models;
using techTask2.ServiceInterface;

namespace techTask2.Service;

public partial class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _repository;
    private readonly IMapper _mapper;
    private readonly IOwnerRepository _ownerRepository;
    private readonly ITransportRepository _transportRepository;
    private readonly IInspectorRepository _inspectorRepository;
    private readonly ISrtsRepository _srtsRepository;

    public ApplicationService(IApplicationRepository repository,
        IOwnerRepository ownerRepository, IMapper mapper, ITransportRepository transportRepository,
        IInspectorRepository inspectorRepository,ISrtsRepository srtsRepository)
    {
        _repository = repository;
        _ownerRepository = ownerRepository;
        _mapper = mapper;
        _transportRepository = transportRepository;
        _inspectorRepository = inspectorRepository;
        _srtsRepository = srtsRepository;
    }

    public IEnumerable<ApplicationDto> GetApplications()
    {
        var applications = _repository.GetApplications();
        var result = _mapper.Map<IEnumerable<ApplicationDto>>(applications);
        return result;
    }

    public ApplicationDto GetApplication(int inspectorId)
    {
        var inspector = _inspectorRepository.GetInspector(inspectorId);
        if (inspector == null)
        {
            throw new Exception("inspector not found");
        }
        var appId = _repository.GetApplications().Where(a => a.OwnerRegion == inspector!.Region && a is { IsAccept: false, InProcess: true }).Min(e => e.Id);
        var app = _repository.GetApplications().FirstOrDefault(a => a.Id == appId);
        if (app == null)
        {
            throw new Exception("application not found");
        }

        var result = _mapper.Map<ApplicationDto>(app);
        return result;
    }

    public bool CheckApplication(ApplicationCreateDto? applicationDto)
    {
       return applicationDto != null;
    }

    public bool CheckOwner(int ownerId,ApplicationCreateDto? applicationDto)
    {
        var owner = _ownerRepository.GetOwner(ownerId);
        if (owner == null)
        {
            return false;
        }
        return owner!.FirstName == applicationDto!.OwnerFirstName && owner.LastName == applicationDto.OwnerLastName &&
               owner.Iin == applicationDto.OwnerIin && owner.Region == applicationDto.OwnerRegion &&
               owner.Address == applicationDto.OwnerAddress;
    }

    public bool CheckTransportInformation(ApplicationCreateDto? applicationDto)
    {
        return MyRegex().IsMatch(applicationDto!.TransportGrnz!) &&
               MyRegex1().IsMatch(applicationDto.TransportVin!) &&
               MyRegex2().IsMatch(applicationDto.TransportCategory!);
    }
    public bool CheckApplicationType(ApplicationCreateDto? applicationDto)
    {
        return applicationDto!.AppType is "Registration" or "De-Registration";
    }

    public bool CheckApplicationTypeWithSrts(ApplicationCreateDto? applicationDto)
    {
        if (applicationDto!.AppType == "Registration")
        {
            var srts = _srtsRepository.GetSrtses().FirstOrDefault(e => e.TransportVin == applicationDto.TransportVin);
            if (srts == null || srts.Sign == true)
            {
                return true;
            }

            return false;
        }

        if (applicationDto.AppType == "De-Registration")
        {
            var srts = _srtsRepository.GetSrtses().FirstOrDefault(e => e.TransportVin == applicationDto.TransportVin && e.OwnerIin == applicationDto.OwnerIin);
            if (srts == null)
            {
                return false;
            }

            if (srts.Sign == true)
            {
                return false;
            }

            return true;
        }

        return false;

    }

    public bool CheckApplicationFromDb(ApplicationCreateDto? applicationDto)
    {
        var application = _repository.GetApplications().FirstOrDefault(e =>
            e.TransportGrnz == applicationDto!.TransportGrnz ||  e.TransportVin == applicationDto.TransportVin);
        return application == null ||  application!.InProcess != true;
    }
   
    

    public bool CheckTransportFromDb(int ownerId,ApplicationCreateDto? applicationDto)
    {
        var transportInDb = _transportRepository.GetTransports().FirstOrDefault(e =>
            e.Grnz == applicationDto!.TransportGrnz && e.Vin == applicationDto.TransportVin);
        return transportInDb == null || transportInDb!.OwnerId == ownerId;
    }
    
    public bool CreateApplicationAndTransport(int ownerId,ApplicationCreateDto? applicationDto)
    {

        var transportFromDb = _transportRepository.GetTransports().FirstOrDefault(t =>
            t.Vin == applicationDto!.TransportVin && t.Grnz == applicationDto.TransportGrnz);
        var transport = new Transport
        {
            OwnerId = ownerId,
            Grnz = applicationDto!.TransportGrnz,
            Category = applicationDto.TransportCategory,
            Vin = applicationDto.TransportVin,
            Marca = applicationDto.TransportMarca
        };
        if (applicationDto!.AppType == "Registration" && transportFromDb == null)
        {
            _transportRepository.CreateTransport(transport);
        }

        if (applicationDto.AppType == "De-Registration" || (applicationDto.AppType == "Registration" && transportFromDb != null) )
        {
            transport = _transportRepository.GetTransports().FirstOrDefault(t => t.Vin == applicationDto.TransportVin);
        }
        var applicationMap = _mapper.Map<Application>(applicationDto);
        applicationMap.AppStatus = "application is being processed";
        applicationMap.OwnerId = ownerId;
        applicationMap.TransportId = transport!.Id;
        applicationMap.OwnerFullName = applicationDto!.OwnerFirstName + ' ' + applicationDto.OwnerLastName;
        applicationMap.OwnerFirstName = applicationDto.OwnerFirstName;
        applicationMap.OwnerLastName = applicationDto.OwnerLastName;
        applicationMap.OwnerIin = applicationDto.OwnerIin;
        applicationMap.OwnerAddress = applicationDto.OwnerAddress;
        applicationMap.OwnerRegion = applicationDto.OwnerRegion;
        applicationMap.AppTime = DateTime.Now.ToUniversalTime();
        applicationMap.Psc = applicationDto.OwnerRegion + " PSC";
        return _repository.CreateApplication(applicationMap);
    }

    public bool CancelApplication( int inspectorId,int applicationId )
    {
        
        var inspector = _inspectorRepository.GetInspector(inspectorId);
        if (inspector == null)
        {
            return false;
        }
        var appId = _repository.GetApplications().Where(a => a.OwnerRegion == inspector!.Region && a.InProcess).Min(e => e.Id);
        if (appId != applicationId)
        {
            return false;
        }
        var app = _repository.GetApplications().FirstOrDefault(a => a.Id == appId);
        app!.AppStatus = "process canceled by inspector";
        app.InProcess = false;
        app.IsAccept = false;
        return _repository.UpdateApplication(app);
    }

    [GeneratedRegex("^\\d{3}[A-Z]{3}(0[1-9]|1[0-9])$")]
    private static partial Regex MyRegex();
    [GeneratedRegex("^[A-HJ-NPR-Z\\d]{8}[X\\d][A-HJ-NPR-Z\\d]{2}\\d{6}$")]
    private static partial Regex MyRegex1();
    [GeneratedRegex("^(A|B|C|D|E|M|T)$")]
    private static partial Regex MyRegex2();
}