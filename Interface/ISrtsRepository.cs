using techTask2.Models;

namespace techTask2.Interface;

public interface ISrtsRepository
{
    IEnumerable<Srts> GetSrtses();
    Srts GetSrts(int srtsId);
    bool CreateSrts(Srts srts);
    bool Save();
    bool UpdateSrts(Srts srts);
}