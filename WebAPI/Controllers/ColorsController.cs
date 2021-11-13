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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _colorService.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _colorService.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var Result = _colorService.Add(color);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

    }
}
