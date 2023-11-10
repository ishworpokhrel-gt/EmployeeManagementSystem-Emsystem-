
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeManagement.Controllers
{
   
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
         
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> Objofcat = _db.Employeess.ToList();
            return View(Objofcat);
            
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Employee emp) 
        {
            if (emp != null)
            {
                _db.Employeess.Add(emp);
                _db.SaveChanges();
                TempData["Success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
            
        }
        [HttpGet]
        public IActionResult Edit(Employee emp , int id)
        {
            var obj = _db.Employeess.FirstOrDefault(x => x.ID== id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edits(Employee emp, int id) 
        { 
            if(emp != null)
            {
                _db.Employeess.Update(emp);
                _db.SaveChanges();
                TempData["Success"] = "Updated Successfully";

                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var obj = _db.Employeess.FirstOrDefault(a=>a.ID == id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult delete( Employee emp)
        {
            if(emp != null)
            {
                _db.Employeess.Remove(emp);
                _db.SaveChanges();
                TempData["Success"] = "Deleted Successfully";

                return RedirectToAction("Index");
            }
            return NotFound();
        }


        [Authorize(Roles =("Admin,Accountant"))]
        public IActionResult LeaveDecide()
        {
            List<LeaveRequest> leaves = _db.LeaveRequests.ToList();
            return View(leaves);
        }

        [Authorize(Roles = ("Admin,Accountant"))]
        public IActionResult Approve(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var app= _db.LeaveRequests.FirstOrDefault(u=>u.ID == id);
            app.FinalDecision = "Approve";
            _db.LeaveRequests.Update(app);
            _db.SaveChanges();
            return RedirectToAction("LeaveDecide");
        }

        [Authorize(Roles = ("Admin,Accountant"))]
        public IActionResult Reject(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var app = _db.LeaveRequests.FirstOrDefault(u => u.ID == id);
            app.FinalDecision = "Reject";
            _db.LeaveRequests.Update(app);
            _db.SaveChanges();
            return RedirectToAction("LeaveDecide");
        }



       



    }
}
