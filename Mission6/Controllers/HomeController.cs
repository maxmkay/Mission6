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
        
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = DbContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(Tasks ta)
        {
            DbContext.Add(ta);
            DbContext.SaveChanges();

            return View("Confirmation");
        }

        public IActionResult TaskView()
        {
            var Tasks = DbContext.Tasks
                .Where(x=> x.Completed == false)
                .ToList();

            return View(Tasks);
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = DbContext.Categories.ToList();

            var tasks = DbContext.Tasks.Single(x => x.TaskId == taskid);

            return View("TaskForm", tasks);
        }

        [HttpPost]
        public IActionResult Edit(Tasks ta)
        {
            DbContext.Update(ta);
            DbContext.SaveChanges();
            return RedirectToAction("TaskView");
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var tasks = DbContext.Tasks.Single(x => x.TaskId == taskid);
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Delete(Tasks ta)
        {
            DbContext.Tasks.Remove(ta);
            DbContext.SaveChanges();

            return RedirectToAction("TaskView");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
