using Business.Abstract;
using Core.Entities.Concreate;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardPaymentsController : ControllerBase
    {
        ICreditCardPaymetService _creditCardPaymentService;

        public CreditCardPaymentsController(ICreditCardPaymetService creditCardPaymentService)
        {
            _creditCardPaymentService = creditCardPaymentService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _creditCardPaymentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _creditCardPaymentService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _creditCardPaymentService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("payment/add")]
        public IActionResult PaymentAdd(CreditCard creditCard)
        {
            var result = _creditCardPaymentService.AddPaymnet(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("payment")]
        public IActionResult Payment(CreditCardPaymentDto creditCardPaymentDto)
        {
            var result = _creditCardPaymentService.NotAddPaymnet(creditCardPaymentDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            var result = _creditCardPaymentService.Delete(creditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
