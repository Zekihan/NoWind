using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoWind.Api.APIModels;
using NoWind.Api.Validations;
using NoWind.Core.Models;
using NoWind.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            this._mapper = mapper;
            this._employeeService = employeeService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<EmployeeAPIModel>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployees();
            var employeesAPIModel = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeeAPIModel>>(employees);
            return Ok(employeesAPIModel);
        }

        [HttpGet("id")]
        public async Task<ActionResult<EmployeeAPIModel>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            var employeeAPIModel = _mapper.Map<Employees, EmployeeAPIModel>(employee);
            return Ok(employeeAPIModel);
        }

        [HttpGet("bossId")]
        public async Task<ActionResult<IEnumerable<EmployeeAPIModel>>> GetEmployeesByBoss(int bossId)
        {
            var employees = await _employeeService.GetEmployeesByBoss(bossId);
            var employeesAPIModel = _mapper.Map<IEnumerable<Employees>, IEnumerable<EmployeeAPIModel>>(employees);
            return Ok(employeesAPIModel);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAPIModel>> CreateEmployee(EmployeeAPIModel employee)
        {
            var validator = new EmployeeValidator(1);
            var validationResult = await validator.ValidateAsync(employee);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var employeeModel = _mapper.Map<EmployeeAPIModel, Employees>(employee);
            await _employeeService.CreateEmployees(employeeModel);
            return Ok(employee);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<EmployeeAPIModel>> DeleteEmployee(int id)
        {
            var employeeToBeDeleted = await _employeeService.GetEmployeeById(id);
            var employeeAPIModel = _mapper.Map<Employees, EmployeeAPIModel>(employeeToBeDeleted);

            await _employeeService.DeleteEmployees(employeeToBeDeleted);
            return Ok(employeeAPIModel);
        }

        [HttpPut("id")]
        public async Task<ActionResult<EmployeeAPIModel>> UpdateCustomer(int id, EmployeeAPIModel employee)
        {
            var validator = new EmployeeValidator(0);
            var validationResult = await validator.ValidateAsync(employee);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var employeeToUpdate = await _employeeService.GetEmployeeById(id);

            if (employeeToUpdate == null)
                return NotFound();

            var employeeModel = _mapper.Map<EmployeeAPIModel, Employees>(employee);

            await _employeeService.UpdateEmployees(employeeToUpdate, employeeModel);

            employeeModel = await _employeeService.GetEmployeeById(id);
            var employeeAPIModel = _mapper.Map<Employees, EmployeeAPIModel>(employeeModel);

            return Ok(employeeAPIModel);
        }
    }
}
