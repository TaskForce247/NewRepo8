using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterLoggic.Core;
using WaterLoggic.Core.Models;
using WaterLoggic.Core.ViewModel;
using WaterLoggic.Persistence;

namespace WaterLoggic.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(String name, String email, String phone, String address)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Phone = phone;
            customer.Address = address;
            customer.Email = email;
            _customerRepository.AddCustomerAsync(customer);
        }

        public void UpdateCustomer()
        {

        }

        public void DeleteCustomer()
        {

        }
    }
}
