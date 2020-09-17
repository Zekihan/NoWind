using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoWind.Api.Resources;
using NoWind.Api.Validations;
using NoWind.Core.Models;
using NoWind.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this._mapper = mapper;
            this._orderService = orderService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetAllOrders()
        {
            var order = await _orderService.GetAllOrders();
            var orderResources = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderResource>>(order);
            return Ok(orderResources);
        }

        [HttpGet("id")]
        public async Task<ActionResult<OrderResource>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            var orderResources = _mapper.Map<Orders, OrderResource>(order);
            return Ok(orderResources);
        }

        [HttpGet("customerId")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetOrderByCustomerId(string customerId)
        {
            var order = await _orderService.GetOrderByCustomerId(customerId);
            var orderResources = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderResource>>(order);
            return Ok(orderResources);
        }

        [HttpGet("employeeId")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> GetOrderByEmployeeId(int employeeId)
        {
            var order = await _orderService.GetOrderByEmployeeId(employeeId);
            var orderResources = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderResource>>(order);
            return Ok(orderResources);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderResource>>> CreateOrder(OrderResource order)
        {
            var validator = new OrderValidator();
            var validationResult = await validator.ValidateAsync(order);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var orders = _mapper.Map<OrderResource, Orders>(order);
            var orderResources = await _orderService.CreateOrder(orders);
            return Ok(orderResources);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> DeleteOrder(int id)
        {
            var orderToBeDeleted = await _orderService.GetOrderById(id);
            var orderResource = _mapper.Map<Orders, OrderResource>(orderToBeDeleted);

            await _orderService.DeleteOrder(orderToBeDeleted);
            return Ok(orderResource);
        }

        [HttpPut("id")]
        public async Task<ActionResult<IEnumerable<OrderResource>>> UpdateOrder(int id, OrderResource order)
        {
            var validator = new OrderValidator();
            var validationResult = await validator.ValidateAsync(order);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var orderToUpdate = await _orderService.GetOrderById(id);

            if (orderToUpdate == null)
                return NotFound();

            var orders = _mapper.Map<OrderResource, Orders>(order);

            await _orderService.UpdateOrder(orderToUpdate, orders);

            var result = await _orderService.GetOrderById(id);
            var res = _mapper.Map<Orders, OrderResource>(result);

            return Ok(res);
        }
    }
}
