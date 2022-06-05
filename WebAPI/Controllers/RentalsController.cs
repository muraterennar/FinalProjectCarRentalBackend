using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _restalService;

        public RentalsController(IRentalService restalService)
        {
            _restalService = restalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _restalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _restalService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetails")]
        public IActionResult GetRentalDetails()
        {
            var result = _restalService.GetRentalDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetailbyid")]
        public IActionResult GetRentalDetailById(int id)
        {
            var result = _restalService.GetRentalDetailById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetailbyuserid")]
        public IActionResult GetRentalDetailByUserId(int userId)
        {
            var result = _restalService.GetRentalDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetailbycarid")]
        public IActionResult GetRentalDetailBycarId(int carId)
        {
            var result = _restalService.GetRentalDetailByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _restalService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _restalService.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _restalService.Delete(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
