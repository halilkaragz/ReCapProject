using Business.Abstract;
using Core.Utilities.Results;
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
            //De
            var Result = _carService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _carService.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);           
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var Result = _carService.Add(car);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }




    }
}
