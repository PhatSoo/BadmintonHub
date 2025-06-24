using BadmintonHub.Databases;
using BadmintonHub.Models;
using BadmintonHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BadmintonHub.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BadmintonHubDbContext _dbContext;

        public CustomerService(BadmintonHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetCustomerAsync(Guid id)
        {
            return await _dbContext.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(customer.Id);
            if (existingCustomer != null)
            {
                _dbContext.Entry(existingCustomer).CurrentValues.SetValues(customer);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
