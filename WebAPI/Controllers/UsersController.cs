using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userservice;
        public UsersController(IUserService userService)
        {
            _userservice = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var Result = _userservice.GetAll();
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var Result = _userservice.Get(id);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var Result = _userservice.Add(user);
            if (Result.Success)
            {
                return Ok(Result);
            }
            return BadRequest(Result);
        }
    }
}
