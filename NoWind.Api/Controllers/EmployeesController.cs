using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoWind.Api.Resources;
using NoWind.Api.Validations;
using NoWind.Core.Models;
using NoWind.Core.Services;

namespace NoWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._employeeService = employeeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> GetAllCustomers()
        {
            var employees = await _employeeService.GetAllEmployees();
            var employeesResources = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeesResource>>(employees);
            return Ok(employeesResources);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> GetCustomerById(int id)
        {
            var employees = await _employeeService.GetEmployeesById(id);
            var employeesResources = _mapper.Map<Employees, EmployeesResource>(employees);
            return Ok(employeesResources);
        }

        [HttpGet("bossId")]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> GetCustomerByCountry(int bossId)
        {
            var employees = await _employeeService.GetEmployeesByBoss(bossId);
            var employeesResources = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeesResource>>(employees);
            return Ok(employeesResources);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> CreateEmployee(EmployeesResource employee)
        {
            var validator = new EmployessValidator(1);
            var validationResult = await validator.ValidateAsync(employee);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var employees = _mapper.Map<EmployeesResource, Employees>(employee);
            var employeesResources = await _employeeService.CreateEmployees(employees);
            return Ok(employeesResources);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> DeleteEmployee(int id)
        {
            var employeeToBeDeleted = await _employeeService.GetEmployeesById(id);
            var employeesResources = _mapper.Map<Employees, EmployeesResource>(employeeToBeDeleted);

            await _employeeService.DeleteEmployees(employeeToBeDeleted);
            return Ok(employeesResources);
        }

        [HttpPut("id")]
        public async Task<ActionResult<IEnumerable<EmployeesResource>>> UpdateCustomer(int id, EmployeesResource employee)
        {
            var validator = new EmployessValidator(0);
            var validationResult = await validator.ValidateAsync(employee);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var employeeToUpdate = await _employeeService.GetEmployeesById(id);

            if (employeeToUpdate == null)
                return NotFound();

            var employees = _mapper.Map<EmployeesResource, Employees>(employee);

            await _employeeService.UpdateEmployees(employeeToUpdate, employees);

            var result = await _employeeService.GetEmployeesById(id);
            var res = _mapper.Map<Employees, EmployeesResource>(result);

            return Ok(res);
        }
    }
}
