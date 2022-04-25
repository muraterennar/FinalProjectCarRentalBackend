using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandImagesController : ControllerBase
    {
        IBrandImageService _brandImageService;

        public BrandImagesController(IBrandImageService brandImageService)
        {
            _brandImageService = brandImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _brandImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _brandImageService.GetBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpGet("getbyimagepath")]
        public IActionResult GetByImagePath(string imagePath)
        {
            var result = _brandImageService.GetImagePath(imagePath);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImagePath(int imageId)
        {
            var result = _brandImageService.GetImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(int brandId, List<IFormFile> files)
        {
            var result = _brandImageService.Add(brandId, files);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int imageId)
        {
            var result = _brandImageService.Delete(imageId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(int imageId, IFormFile file)
        {
            var result = _brandImageService.Update(imageId, file);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
