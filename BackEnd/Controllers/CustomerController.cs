﻿using BackEnd.Models;
using BackEnd.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEnd.ViewModels;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerVm>> GetAll()
        {
            IEnumerable<Customer> result = await _customerRepository.GetAllAsync();
            return result.Select(x => new CustomerVm
            {
                Id = x.Id,
                Address = x.Address,
                Name = x.Name,
                SubscriptionState = x.SubscriptionState,
                InvoiceNumbers = x.Invoices is not null ? x.Invoices.Count : 0
            });
        }


        [HttpPost]
        public async Task<Customer> Create(Customer customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }
    }
}