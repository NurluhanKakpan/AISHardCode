namespace techTask2.Models;

public class Application
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int TransportId { get; set; }
    public string? OwnerFullName { get; set; }
    public string? OwnerFirstName { get; set; }
    public string? OwnerLastName { get; set; }
    public string? OwnerIin { get; set; }
    public string? OwnerAddress { get; set; }
    public string? OwnerRegion { get; set; }
    public string? TransportGrnz { get; set; }
    public string? TransportVin { get; set; }
    public string? TransportCategory { get; set; }
    public string? TransportMarca { get; set; }
    public string? Psc { get; set; }
    public string? AppType { get; set; }
    public string? AppStatus { get; set; }
    public bool InProcess { get; set; } = true;
    public bool IsAccept { get; set; } = false;
    public DateTime AppTime { get; set; }
    public Owner? Owner { get; set; }
    public Transport? Transport { get; set; }
}