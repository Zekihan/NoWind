using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoWind.Api.Resources;
using NoWind.Api.Validations;
using NoWind.Core.Models;
using NoWind.Data.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomersService _customersService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomersService customersService, IMapper mapper)
        {
            this._mapper = mapper;
            this._customersService = customersService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> GetAllCustomers()
        {
            var customers = await _customersService.GetAllCustomers();
            var customersResources = _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerResource>>(customers);
            return Ok(customersResources);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> GetCustomerById(string id)
        {
            var customers = await _customersService.GetCustomerById(id);
            var customersResources = _mapper.Map<Customers, CustomerResource>(customers);
            return Ok(customersResources);
        }

        [HttpGet("country")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> GetCustomerByCountry(string country)
        {
            var customers = await _customersService.GetCustomersByCountry(country);
            var customersResources = _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerResource>>(customers);
            return Ok(customersResources);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> CreateCustomer(CustomerResource customer)
        {
            var validator = new CustomerValidator();
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var customersResources = _mapper.Map<CustomerResource, Customers>(customer);
            var customers = await _customersService.CreateCustomer(customersResources);
            return Ok(customersResources);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> DeleteCustomer(string id)
        {
            var customerToBeDeleted = await _customersService.GetCustomerById(id);
            var customersResources = _mapper.Map<Customers, CustomerResource>(customerToBeDeleted);

            await _customersService.DeleteCustomer(customerToBeDeleted);
            return Ok(customersResources);
        }

        [HttpPut("id")]
        public async Task<ActionResult<IEnumerable<CustomerResource>>> UpdateCustomer(string id, CustomerResource customer)
        {
            var validator = new CustomerValidator();
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var customerToUpdate = await _customersService.GetCustomerById(id);

            if (customerToUpdate == null)
                return NotFound();

            var customers = _mapper.Map<CustomerResource, Customers>(customer);

            await _customersService.UpdateCustomer(customerToUpdate, customers);

            var result = await _customersService.GetCustomerById(id);
            var res = _mapper.Map<Customers, CustomerResource>(result);

            return Ok(res);
        }
    }
}
