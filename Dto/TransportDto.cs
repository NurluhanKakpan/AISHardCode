namespace techTask2.Dto;

public class TransportDto
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string? Grnz { get; set; }
    public string? Vin { get; set; }
    public string? Category { get; set; }
    public string? Marca { get; set; }
    public bool HaveSrts { get; set; } = false;
}