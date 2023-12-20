using BackEnd.Interfaces;
using BackEnd.Models;
using BackEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer, string> _customerRepository;

        public CustomerController(IRepository<Customer, string> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(List<CustomerVm>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Customer> result = await _customerRepository.GetAllAsync();
            return Ok(result.Select(x => new CustomerVm
            {
                Id = x.Id,
                Address = x.Address,
                Name = x.Name,
                SubscriptionState = x.SubscriptionState,
                InvoiceNumbers = x.Invoices is not null ? x.Invoices.Count : 0
            }));
        }


        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _customerRepository.GetByKey(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [Route("Create")]
        public async Task<Customer> Create(Customer customer)
        {
            return await _customerRepository.CreateAsync(customer);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [Route("Update")]
        public async Task<Customer> Update(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }
    }
}
