using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService ;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _customerService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _customerService.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }
        [HttpGet("getcustomersdetails")]
        public IActionResult GetCustomersDatails()
        {
            var Result = _customerService.GetCustomerDetails();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var Result = _customerService.Add(customer);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);

        }
    }
}
