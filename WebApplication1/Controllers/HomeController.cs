using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var temp = new List<Student>()
            {
                new Student(){ Name="Kalpesh", City="Ahmedabad", Number="1234567890"},
                new Student(){ Name="Jalpesh", City="Ahmedabad", Number="3334567890"},
                new Student(){ Name="Mitesh", City="Rajkot", Number="4234567890"},
                new Student(){ Name="Raj", City="Baroda", Number="3234567890"},
                new Student(){ Name="Jay", City="Bharuch", Number="544567890"}
            };
            var students = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                students.AddRange(temp);
            }

            return new ViewAsPdf(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
    }
}
