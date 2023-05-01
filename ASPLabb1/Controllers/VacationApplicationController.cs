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
        // GET: VacationApplicationController
        public ActionResult Index()
        {
            var aplList = _context.VacationApplication.ToList();
            List<ApplicationInfoViewmodel> infoList = new();
            foreach(VacationApplication item  in aplList)
            {
                ApplicationInfoViewmodel x = new();
                x.Id = item.Id;
                x.StartDate = item.StartDate;
                x.EndDate = item.StartDate;
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

        // GET: VacationApplicationController/Details/5
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
                x.EndDate = item.StartDate;
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
        // GET: VacationApplicationController/Create
        public ActionResult ApplicationList(ApplicationInfoViewmodel model)
        {
            return PartialView("_MyPartialView", model);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacationApplicationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationApplication model)
        {
            _context.Add(model);
            _context.SaveChanges();

            return View();
        }

        // GET: VacationApplicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VacationApplicationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VacationApplicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VacationApplicationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
