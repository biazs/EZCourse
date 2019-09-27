using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EZCourse.Controllers
{
    public class TestController : Controller
    {
        public IActionResult JsonOut(int id, Person person)
        {
            var obj = new
            {
                Id = id,
                Person = person
            };
            return Json(obj);
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

    }
}