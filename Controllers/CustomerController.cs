using BadmintonHub.Dtos.CustomerDto;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET /customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersAsync()
        {
            var results = await _customerService.GetCustomersAsync();
            return Ok(results.Select(c => c.AsDto()));
        }

        // GET /customers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(Guid id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            return Ok(customer.AsDto());
        }

        // POST /customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomerAsync([FromBody] CreateCustomerDto customerDto)
        {
            var newCustomer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                IsVip = customerDto.IsVip,
                Address = customerDto.Address
            };

            await _customerService.CreateCustomerAsync(newCustomer);

            return CreatedAtAction(nameof(GetCustomerAsync), new { id = newCustomer.Id }, newCustomer.AsDto());
        }

        // PUT /customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomerAsync(Guid id, [FromBody] UpdateCustomerDto customerDto)
        {
            var existingCustomer = await _customerService.GetCustomerAsync(id);
            if (existingCustomer is null)
            {
                return NotFound();
            }

            existingCustomer.Name = customerDto.Name;
            existingCustomer.Email = customerDto.Email;
            existingCustomer.PhoneNumber = customerDto.PhoneNumber;
            existingCustomer.IsVip = customerDto.IsVip;
            existingCustomer.Address = customerDto.Address;

            await _customerService.UpdateCustomerAsync(existingCustomer);
            return NoContent();
        }
    }
}
