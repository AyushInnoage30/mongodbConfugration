using ConnectionMongoBd.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using MongodbServices;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConnectionMongoBd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoDBController : ControllerBase
    {
        private readonly MongoDBService _mongodbServices;

        public MongoDBController(MongoDBService mongodbServices)
        {
            _mongodbServices = mongodbServices;
        }
             
        // This HttpGet and HttpPost is used for UserCollection
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var collection = _mongodbServices.GetCollection<User>("UserCollection");
            var users = await collection.Find(user => true).ToListAsync(); 
            return Ok(users);
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
            var collection = _mongodbServices.GetCollection<User>("UserCollection");
            user.Id = null;
            await collection.InsertOneAsync(user);
            return Ok("Successfully Inserted");
        }



        // This HttpGet and HttpPost is used for DepartmentCollection
        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments() { 
        
           var collection = _mongodbServices.GetCollection<Department>("DepartmentCollection");
            var departments = await collection.Find(department => true).ToListAsync();
            return Ok(departments);
        }


        [HttpPost]
        [Route("InsertDepartments")]
        public async Task<IActionResult> InsertDepartments([FromBody] Department department)
        {
            var collection = _mongodbServices.GetCollection<Department>("DepartmentCollection");
            department.Id = null;
            await collection.InsertOneAsync(department);
            return Ok("Successfully Inserted Department");
        }
    }
}
