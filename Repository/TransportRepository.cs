using techTask2.Data;
using techTask2.Interface;
using techTask2.Models;

namespace techTask2.Repository;

public class TransportRepository : ITransportRepository
{
    private readonly DataContext _context;

    public TransportRepository(DataContext context)
    {
        _context = context;
    }
    public ICollection<Transport> GetTransports()
    {
        return _context.Transports.ToList();
    }

    public Transport? GetTransport(int transportId)
    {
        return _context.Transports.FirstOrDefault(t => t.Id == transportId);
    }

    public bool CreateTransport(Transport transport)
    {
        _context.Transports.Add(transport);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}