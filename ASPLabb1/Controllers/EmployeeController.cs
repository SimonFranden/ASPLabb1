using ASPLabb1.Data;
using ASPLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        // GET: VacationApplicationController
        public ActionResult Index()
        {
            var modelList = _context.Employees.ToList();
            
            return View(modelList);
        }
    }
}
