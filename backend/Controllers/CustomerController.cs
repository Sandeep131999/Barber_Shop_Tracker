using backend.DTO;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

/// <summary>
/// Controller for customer-related API endpoints
/// </summary>
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IVisitorService _visitorService;

    public CustomerController(ICustomerService customerService,IVisitorService visitorService)
    {
        _customerService = customerService;
        _visitorService = visitorService;
    }

    /// <summary>
    /// Creates a new customer
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto  customers)
    {
        var customerId = await _customerService.InsertAsync(customers);
        var visitor = new Visitor
        {
            CustomerId = customerId
        };
        var visitId = await _visitorService.CreateAsync(visitor);
        return Ok(visitId);
    }
}

