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
        public async Task<ActionResult<IEnumerable<ShipperAPIModel>>> GetAllShippers()
        {
            var shippers = await _shipperService.GetAllShippers();
            var shippersAPIModel = _mapper.Map<IEnumerable<Shippers>, IEnumerable<ShipperAPIModel>>(shippers);
            return Ok(shippersAPIModel);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ShipperAPIModel>> GetShipperById(int id)
        {
            var shipper = await _shipperService.GetShipperById(id);
            var shipperAPIModel = _mapper.Map<Shippers, ShipperAPIModel>(shipper);
            return Ok(shipperAPIModel);
        }

        [HttpPost]
        public async Task<ActionResult<ShipperAPIModel>> CreateShipper(ShipperAPIModel shipper)
        {
            var validator = new ShipperValidator();
            var validationResult = await validator.ValidateAsync(shipper);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shippers = _mapper.Map<ShipperAPIModel, Shippers>(shipper);
            var shipperAPIModel = await _shipperService.CreateShipper(shippers);
            return Ok(shipperAPIModel);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ShipperAPIModel>> DeleteShipper(int id)
        {
            var shipperToBeDeleted = await _shipperService.GetShipperById(id);
            var shipperAPIModel = _mapper.Map<Shippers, ShipperAPIModel>(shipperToBeDeleted);

            await _shipperService.DeleteShipper(shipperToBeDeleted);
            return Ok(shipperAPIModel);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ShipperAPIModel>> UpdateShipper(int id, ShipperAPIModel shipper)
        {
            var validator = new ShipperValidator();
            var validationResult = await validator.ValidateAsync(shipper);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shipperToUpdate = await _shipperService.GetShipperById(id);

            if (shipperToUpdate == null)
                return NotFound();

            var shipperModel = _mapper.Map<ShipperAPIModel, Shippers>(shipper);

            await _shipperService.UpdateShipper(shipperToUpdate, shipperModel);

            shipperModel = await _shipperService.GetShipperById(id);
            var shipperAPIModel = _mapper.Map<Shippers, ShipperAPIModel>(shipperModel);

            return Ok(shipperAPIModel);
        }
    }
}
