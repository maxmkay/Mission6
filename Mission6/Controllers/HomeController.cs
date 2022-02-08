using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        //This is added so we can add stuff to the database
        private TaskInfoContext DbContext { get; set; }

        //Same as above
        public HomeController(TaskInfoContext someName)
        {
            DbContext = someName;
        }



        public IActionResult Index()
        {
            return View();
        }

       
    }
}
