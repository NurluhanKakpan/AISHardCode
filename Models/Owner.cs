using System.ComponentModel.DataAnnotations;

namespace techTask2.Models;

public class Owner
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Iin { get; set; }
    public string? Address { get; set; }
    public string? Region { get; set; }
    public string? FullName { get; set; }
    public IEnumerable<Application>? Applications { get; set; }
    public IEnumerable<Transport>? Transports { get; set; }
    public IEnumerable<Srts>? OwnerSrts { get; set; }
    
}