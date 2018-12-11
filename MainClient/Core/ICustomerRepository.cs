using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainClient.Core.Models;
using MainClient.Core.Dto;
using MainClient.Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace MainClient.Core
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
