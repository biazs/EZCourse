using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZCourse.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var users = new List<User>
            {
                new User { Id =1, Name = "Mr Blue"},
                new User { Id =2, Name = "Mr Green"},
                new User { Id =3, Name = "Mr Purple"}
            };


            return View(users);
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
}