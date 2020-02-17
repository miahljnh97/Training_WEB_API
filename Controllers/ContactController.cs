using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Training.Controllers;
using Training.Model;

namespace Training.Controllers
{
    [ApiController]
    [Route("info")]

    public class ContactController : ControllerBase
    {
        private static List<User> Users = new List<User>()
        {
            new User(){Id = 1, Name = "hello1", Username = "hello1@hello.com" },
            new User(){Id = 2, Name = "hello2", Username = "hello2@hello.com" },
            new User(){Id = 3, Name = "hello3", Username = "hello3@hello.com" },
            new User(){Id = 4, Name = "hello4", Username = "hello4@hello.com" },
            new User(){Id = 5, Name = "hello5", Username = "hello5@hello.com" },
            new User(){Id = 6, Name = "hello6", Username = "hello6@hello.com" }
        };




        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(new { status = "yes", message = "you got the data", data = Users });
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(new { status = "yes", message = "you got the data", data = Users.Find(e => e.Id == id) });
        //}

        //[HttpPost]
        //public IActionResult ContactAdd(User user)
        //{
        //    var userAdd = new User() { Id = 7, Name = "hello7", Username = "hello7@hello.com" };
        //    Users.Add(userAdd);
        //    return Ok(Users);
        //}

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(Users.First(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult ContactAdd(User user)
        {
            //var addUser = User.ToList();

            Users.Add(user);

            return Ok(Users);
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            return Ok(Users.RemoveAll(k => k.Id == id));
        }

        //[HttpPatch]
        //public IActionResult UpdateUser(UserRequest user, int id)
        //{

        //}

    }
}
