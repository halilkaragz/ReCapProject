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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _rentalService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {            
            var Result = _rentalService.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);            
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var Result = _rentalService.Add(rental);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);            
        }

    }
}
