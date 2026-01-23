using backend.Models;
using backend.Repository;

namespace backend.Services;

/// <summary>
/// SERVICE implementation for Visitors.
/// </summary>
public class VisitorService : IVisitorService
{
    private readonly IVisitorRepository _repository;

    public VisitorService(IVisitorRepository repository)
    {
        _repository = repository;
    }


    public async Task<Guid> CreateAsync(Visitor visits)
    {
        
        var visit = new Visitor
        {
            CustomerId = visits.CustomerId,
            ShopId = visits.ShopId,
            BarberId = visits.BarberId
        };

        // 2) Call repository
        return await _repository.InsertAsync(visit);
    }
}
