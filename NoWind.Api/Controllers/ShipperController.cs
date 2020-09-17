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
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperService;
        private readonly IMapper _mapper;

        public ShipperController(IShipperService shipperService, IMapper mapper)
        {
            this._mapper = mapper;
            this._shipperService = shipperService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ShipperResource>>> GetAllshippers()
        {
            var shipper = await _shipperService.GetAllShippers();
            var shipperResources = _mapper.Map<IEnumerable<Shippers>, IEnumerable<ShipperResource>>(shipper);
            return Ok(shipperResources);
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<ShipperResource>>> GetshipperById(int id)
        {
            var shipper = await _shipperService.GetShipperById(id);
            var shipperResources = _mapper.Map<Shippers, ShipperResource>(shipper);
            return Ok(shipperResources);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ShipperResource>>> CreateShipper(ShipperResource shipper)
        {
            var validator = new ShippersValidator();
            var validationResult = await validator.ValidateAsync(shipper);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shippers = _mapper.Map<ShipperResource, Shippers>(shipper);
            var shipperResources = await _shipperService.CreateShipper(shippers);
            return Ok(shipperResources);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<IEnumerable<ShipperResource>>> DeleteShipper(int id)
        {
            var shipperToBeDeleted = await _shipperService.GetShipperById(id);
            var shipperResource = _mapper.Map<Shippers, ShipperResource>(shipperToBeDeleted);

            await _shipperService.DeleteShipper(shipperToBeDeleted);
            return Ok(shipperResource);
        }

        [HttpPut("id")]
        public async Task<ActionResult<IEnumerable<ShipperResource>>> UpdateShipper(int id, ShipperResource shipper)
        {
            var validator = new ShippersValidator();
            var validationResult = await validator.ValidateAsync(shipper);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shipperToUpdate = await _shipperService.GetShipperById(id);

            if (shipperToUpdate == null)
                return NotFound();

            var shippers = _mapper.Map<ShipperResource, Shippers>(shipper);

            await _shipperService.UpdateShipper(shipperToUpdate, shippers);

            var result = await _shipperService.GetShipperById(id);
            var res = _mapper.Map<Shippers, ShipperResource>(result);

            return Ok(res);
        }
    }
}
