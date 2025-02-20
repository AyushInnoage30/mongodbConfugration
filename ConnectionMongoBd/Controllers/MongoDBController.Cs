using ConnectionMongoBd.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using MongodbServices;

namespace ConnectionMongoBd.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class MongoDBController : Controller
    {

        public readonly MOngoDBService _mongodbServices;
        public MongoDBController(MOngoDBService mongodbServices)
        {
            _mongodbServices = mongodbServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUSer()
        {
            var users = await _mongodbServices.GetUserAsync();
            if (!users.Equals(null))
            {
                return Ok($"Connectin Successfull mongodb: {users}");
            }

            return NotFound("Not Found");

        }

        [HttpPost]
        public async Task<IActionResult> CreatedUser([FromBody] User user)
        {
            if(!user.Equals(null))
            {
               await  _mongodbServices.CreatedUserAsync(user);
                return Ok($"User Created: ");
              
            }
            return BadRequest("User is null");
        }
    }

}
