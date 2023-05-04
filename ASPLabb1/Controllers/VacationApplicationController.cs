using ASPLabb1.Data;
using ASPLabb1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLabb1.Controllers
{
    public class VacationApplicationController : Controller
    {
        private readonly DataContext _context;
        public VacationApplicationController(DataContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var aplList = _context.VacationApplication.ToList();
            List<ApplicationInfoViewmodel> infoList = new();
            foreach(VacationApplication item  in aplList)
            {
                ApplicationInfoViewmodel x = new();
                x.Id = item.Id;
                x.StartDate = item.StartDate;
                x.EndDate = item.EndDate;
                x.ApplicationDate = item.ApplicationDate;
                x.VacationType = item.VacationType;
                try
                {
                    x.EmployeeName = _context.Employees.SingleOrDefault(e => e.EmployeeId == item.EmployeeId).FName;
                }
                catch
                {
                    x.EmployeeName = "Employee not found";
                }
                infoList.Add(x);
            }

            ViewData["selectedFilter"] = "All";

            return View(infoList);
        }

        public ActionResult ByMonth(int date)
        {
            var aplList = _context.VacationApplication.ToList();
            List<ApplicationInfoViewmodel> infoList = new();
            foreach (VacationApplication item in aplList)
            {
                if(item.ApplicationDate.Month == date)
                {
                    ApplicationInfoViewmodel x = new();
                    x.Id = item.Id;
                    x.StartDate = item.StartDate;
                    x.EndDate = item.EndDate;
                    x.ApplicationDate = item.ApplicationDate;
                    x.VacationType = item.VacationType;
                    try
                    {
                        x.EmployeeName = _context.Employees.SingleOrDefault(e => e.EmployeeId == item.EmployeeId).FName;
                    }
                    catch
                    {
                        x.EmployeeName = "Employee not found";
                    }
                    infoList.Add(x);
                }                
            }

            ViewData["selectedFilter"] = "All";

            return View(infoList);
        }

 
        public ActionResult Details(int id)
        {
            var aplList = _context.VacationApplication
                        .Where(e => e.EmployeeId == id)
                        .ToList();


            List<ApplicationInfoViewmodel> infoList = new();
            foreach (VacationApplication item in aplList)
            {
                ApplicationInfoViewmodel x = new();
                x.Id = item.Id;
                x.StartDate = item.StartDate;
                x.EndDate = item.EndDate;
                x.ApplicationDate = item.ApplicationDate;
                x.VacationType = item.VacationType;
                try
                {
                    x.EmployeeName = _context.Employees.SingleOrDefault(e => e.EmployeeId == item.EmployeeId).FName;
                }
                catch
                {
                    x.EmployeeName = "Employee not found";
                }
                infoList.Add(x);
            }

            return View(infoList);

        }
     
        public ActionResult ApplicationList(ApplicationInfoViewmodel model)
        {
            return PartialView("_MyPartialView", model);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationApplication model)
        {
            model.ApplicationDate = DateTime.Now;
            _context.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
