using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getcardetailsidall")]
        public IActionResult GetCarDetailsIdAll()
        {
            var result = _carService.GetCarDetailsIdAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsidbyid")]
        public IActionResult GetCarDetailsIdById(int id)
        {
            var result = _carService.GetCarDetailsIdById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsidbybrandid")]
        public IActionResult GetCarDetailsIdByBrandId(int brandId)
        {
            var result = _carService.GetCarDetailsIdByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsidbycolorid")]
        public IActionResult GetCarDetailsIdByColorId(int colorId)
        {
            var result = _carService.GetCarDetailsIdByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsidbyimageid")]
        public IActionResult GetCarDetailsIdByImageId(int imageId)
        {
            var result = _carService.GetCarDetailsIdByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getcardetailsnameall")]
        public IActionResult GetCarDetailsNameAll()
        {
            var result = _carService.GetCarDetailsNameAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsnamebyid")]
        public IActionResult GetCarDetailsNameById(int id)
        {
            var result = _carService.GetCarDetailsNameById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsnamebybrandname")]
        public IActionResult GetCarDetailsNameByBrandName(string brandName)
        {
            var result = _carService.GetCarDetailsNameByBrandName(brandName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsnamebycolorname")]
        public IActionResult GetCarDetailsNameByColorName(string colorName)
        {
            var result = _carService.GetCarDetailsNameByColorName(colorName);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetailsnamebyimagepath")]
        public IActionResult GetCarDetailsNameByImagePath(string imagePath)
        {
            var result = _carService.GetCarDetailsNameByImagePath(imagePath);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
