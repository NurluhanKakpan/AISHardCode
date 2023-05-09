namespace techTask2.Models;

public  class Srts
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public int TransportId { get; set; }
    public string? OwnerFullName { get; set; }
    public string? OwnerIin { get; set; }
    public string? OwnerRegion { get; set; }
    public string? TransportGrnz { get; set; }
    public string? TransportVin { get; set; }
    public string? TransportCategory { get; set; }
    public string? TransportMarca { get; set; }
    public string? SrtsNumber { get; set; }
    public bool Sign { get; set; }
    public Transport? Transport { get; set; }
    public Owner? Owner { get; set; }
}