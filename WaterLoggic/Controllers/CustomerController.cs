﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterLoggic.Core;
using WaterLoggic.Core.Models;
using WaterLoggic.Core.ViewModel;
using WaterLoggic.Persistence;
using MainClient;
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
          //      Form1.MandatoryfieldsWarning();
            }
            
        }

        public void UpdateCustomer(String name, String email, String phone, String address)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Phone = phone;
            customer.Address = address;
            customer.Email = email;
            _customerRepository.AddCustomerAsync(customer);
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public void UpdateView()
        {

        }
    }
}
