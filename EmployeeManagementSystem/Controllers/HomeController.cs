using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            //List<Employee> Objofemp = _db.Employeess.ToList();
            var Objofemp = _db.Employeess.FromSqlRaw("SELECT * FROM get_all_employees()").ToList();
            return View(Objofemp);
        }

        public IActionResult Details(int id)
        {
            var obj = _db.Employeess.FirstOrDefault(a => a.Id == id);
            return View(obj);
        }

        public IActionResult Leave()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Leave(LeaveRequest request)
        {
            if (request == null)
            {
                return NotFound();
            }
            _db.Add(request);
            _db.SaveChanges();
            return RedirectToAction("LeaveTable");

        }

        public IActionResult LeaveTable()
        {
            List<LeaveRequest> req = _db.LeaveRequests.ToList();
            return View(req);
        }

        public IActionResult Slip(int id)
        {
            Employee? emp = _db.Employeess.FirstOrDefault(u => u.Id == id);
            if (emp == null)
            {
                return BadRequest();
            }
            return View(emp);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
