using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoWind.Api.APIModels;
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
        public async Task<ActionResult<IEnumerable<CustomerAPIModel>>> GetAllCustomers()
        {
            var customers = await _customersService.GetAllCustomers();
            var customersAPIModel = _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerAPIModel>>(customers);
            return Ok(customersAPIModel);
        }

        [HttpGet("id")]
        public async Task<ActionResult<CustomerAPIModel>> GetCustomerById(string id)
        {
            var customer = await _customersService.GetCustomerById(id);
            var customerAPIModel = _mapper.Map<Customers, CustomerAPIModel>(customer);
            return Ok(customerAPIModel);
        }

        [HttpGet("country")]
        public async Task<ActionResult<IEnumerable<CustomerAPIModel>>> GetCustomersByCountry(string country)
        {
            var customers = await _customersService.GetCustomersByCountry(country);
            var customersAPIModel = _mapper.Map<IEnumerable<Customers>, IEnumerable<CustomerAPIModel>>(customers);
            return Ok(customersAPIModel);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerAPIModel>> CreateCustomer(CustomerAPIModel customer)
        {
            var validator = new CustomerValidator();
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var customerModel = _mapper.Map<CustomerAPIModel, Customers>(customer);
            await _customersService.CreateCustomer(customerModel);
            return Ok(customer);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<CustomerAPIModel>> DeleteCustomer(string id)
        {
            var customerToBeDeleted = await _customersService.GetCustomerById(id);
            var customerAPIModel = _mapper.Map<Customers, CustomerAPIModel>(customerToBeDeleted);

            await _customersService.DeleteCustomer(customerToBeDeleted);
            return Ok(customerAPIModel);
        }

        [HttpPut("id")]
        public async Task<ActionResult<CustomerAPIModel>> UpdateCustomer(string id, CustomerAPIModel customer)
        {
            var validator = new CustomerValidator();
            var validationResult = await validator.ValidateAsync(customer);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var customerToUpdate = await _customersService.GetCustomerById(id);

            if (customerToUpdate == null)
                return NotFound();

            var customerModel = _mapper.Map<CustomerAPIModel, Customers>(customer);

            await _customersService.UpdateCustomer(customerToUpdate, customerModel);

            customerModel = await _customersService.GetCustomerById(id);
            customer = _mapper.Map<Customers, CustomerAPIModel>(customerModel);

            return Ok(customer);
        }
    }
}
