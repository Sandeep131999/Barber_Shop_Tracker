using backend.Models;

namespace backend.Services;

public interface IVisitorService
{
    Task<Guid> CreateAsync(Visitor visits);
}
