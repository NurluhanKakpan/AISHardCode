using System.Net.Mime;

namespace techTask2.Models;

public class Transport
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string? Grnz { get; set; }
    public string? Vin { get; set; }
    public string? Category { get; set; }
    public string? Marca { get; set; }
    public IEnumerable<Application>? Applications  { get; set; }
    public Owner? Owner { get; set; }
    public bool HaveSrts { get; set; } = false;
    public Srts? Srts { get; set; }
}