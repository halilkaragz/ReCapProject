using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {         
            var Result = _brandService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _brandService.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            var Result = _brandService.Add(brand);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }
    }
}
