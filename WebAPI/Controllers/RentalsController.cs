﻿using Business.Abstract;
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

        [HttpGet("getrentaldetailbycustomer")]
        public IActionResult GetRentalDetailByCustomer(int customerId)
        {
            var result = _restalService.GetRentalDetailByCustomer(customerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentaldetailbycar")]
        public IActionResult GetRentalDetailByCar(int carId)
        {
            var result = _restalService.GetRentalDetailByCar(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentalbycar")]
        public IActionResult GetRentalByCar(int carId)
        {
            var result = _restalService.GetRentalByCar(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getrentalbyid")]
        public IActionResult GetRentalById(int id)
        {
            var result = _restalService.GetRentalById(id);
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
