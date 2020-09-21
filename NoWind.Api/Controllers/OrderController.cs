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
        public async Task<ActionResult<IEnumerable<OrderAPIModel>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            var ordersAPIModel = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderAPIModel>>(orders);
            return Ok(ordersAPIModel);
        }

        [HttpGet("id")]
        public async Task<ActionResult<OrderAPIModel>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            var orderAPIModel = _mapper.Map<Orders, OrderAPIModel>(order);
            return Ok(orderAPIModel);
        }

        [HttpGet("customerId")]
        public async Task<ActionResult<IEnumerable<OrderAPIModel>>> GetOrdersByCustomerId(string customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerId(customerId);
            var ordersAPIModel = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderAPIModel>>(orders);
            return Ok(ordersAPIModel);
        }

        [HttpGet("employeeId")]
        public async Task<ActionResult<IEnumerable<OrderAPIModel>>> GetOrdersByEmployeeId(int employeeId)
        {
            var orders = await _orderService.GetOrdersByEmployeeId(employeeId);
            var ordersAPIModel = _mapper.Map<IEnumerable<Orders>, IEnumerable<OrderAPIModel>>(orders);
            return Ok(ordersAPIModel);
        }

        [HttpPost]
        public async Task<ActionResult<OrderAPIModel>> CreateOrder(OrderAPIModel order)
        {
            var validator = new OrderValidator();
            var validationResult = await validator.ValidateAsync(order);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var orderModel = _mapper.Map<OrderAPIModel, Orders>(order);
            var orderAPIModel = await _orderService.CreateOrder(orderModel);
            return Ok(orderAPIModel);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<OrderAPIModel>> DeleteOrder(int id)
        {
            var orderToBeDeleted = await _orderService.GetOrderById(id);
            if (orderToBeDeleted == null)
                return NotFound();
            var orderAPIModel = _mapper.Map<Orders, OrderAPIModel>(orderToBeDeleted);

            await _orderService.DeleteOrder(orderToBeDeleted);
            return Ok(orderAPIModel);
        }

        [HttpPut("id")]
        public async Task<ActionResult<OrderAPIModel>> UpdateOrder(int id, OrderAPIModel order)
        {
            var validator = new OrderValidator();
            var validationResult = await validator.ValidateAsync(order);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var orderToUpdate = await _orderService.GetOrderById(id);

            if (orderToUpdate == null)
                return NotFound();

            var orderModel = _mapper.Map<OrderAPIModel, Orders>(order);

            await _orderService.UpdateOrder(orderToUpdate, orderModel);

            orderModel = await _orderService.GetOrderById(id);
            var orderAPIModel = _mapper.Map<Orders, OrderAPIModel>(orderModel);

            return Ok(orderAPIModel);
        }
    }
}
