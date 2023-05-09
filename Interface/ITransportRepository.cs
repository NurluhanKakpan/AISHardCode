using techTask2.Models;

namespace techTask2.Interface;

public interface ITransportRepository
{
    ICollection<Transport> GetTransports();
    Transport? GetTransport(int transportId);
    bool CreateTransport(Transport transport);
    bool Save();
}