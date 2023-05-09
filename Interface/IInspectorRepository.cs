using techTask2.Models;

namespace techTask2.Interface;

public interface IInspectorRepository
{
    IEnumerable<Inspector> GetInspectors();
    Inspector? GetInspector(int inspectorId);
    bool CreateInspector(Inspector inspector);
    bool Save();
}