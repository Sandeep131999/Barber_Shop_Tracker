using backend.DTO;
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

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Creates a new customer
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto dto)
    {
        await _customerService.CreateAsync(dto);
        return Ok();
    }
}

