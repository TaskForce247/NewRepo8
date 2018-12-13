using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainClient.Core.Models;
using MainClient.Core;
using MainClient.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace MainClient.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _context.Customers.AsQueryable();
            return await customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int Id)
        {
            return await _context.Customers.FirstAsync(e => e.Id == Id);

        }

        public async Task<IEnumerable<Customer>> GetCustomersByName(string name)
        {
            var customers = _context.Customers.Where
                (e => e.Name == name);
            if (customers != null)
                return await customers.ToListAsync();
            else
                return null;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
        }
        public void DeleteCustomer(int id)
        {
            var cust = new Customer { Id = id };
            _context.Entry(cust).State = EntityState.Deleted;
        }
    }
}
