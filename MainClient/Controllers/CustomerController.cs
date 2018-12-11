using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MainClient.Core;
using MainClient.Core.Models;
using MainClient.Core.ViewModel;
using MainClient.Persistence;

namespace MainClient.Controllers
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
            
            if(!String.IsNullOrWhiteSpace(name) &&
               !String.IsNullOrWhiteSpace(email) &&
               !String.IsNullOrWhiteSpace(phone) &&
               !String.IsNullOrWhiteSpace(address))
            {
                Customer customer = new Customer();
                customer.Name = name;
                customer.Phone = phone;
                customer.Address = address;
                customer.Email = email;
                _customerRepository.AddCustomerAsync(customer);
            }
            else
            {
                
            }
            
        }

        public void UpdateCustomer()
        {

        }

        public void DeleteCustomer()
        {

        }
    }
}
