using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterLoggic.Core.Models;
using WaterLoggic.Core.Dto;
using WaterLoggic.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace WaterLoggic.Core
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int Id);

        Task<IEnumerable<Customer>> GetCustomersByName(string name);

        void UpdateCustomer(Customer customer);
        Task AddCustomerAsync(Customer customer);
        void DeleteCustomer(int id);
    }
}
