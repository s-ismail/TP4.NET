using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prog.NETTp4.Models;
using Prog.NETTp4.Models.ViewModel;

namespace Prog.NETTp4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Tp4CompanyDbContext context;

        public EmployeeController(Tp4CompanyDbContext context)
        {
            this.context = context;
        }

        // GET: EmployeeController1
        public ActionResult Index()
        {
            var query = from e in context.Employees
                        join
                        d in context.Departements
                        on e.IdDepartement equals d.IdDepartement
                        select new EmployeeVM()
                        {
                            EmployeeId = e.EmployeeId,
                            Name = e.Name,
                            Address = e.Address,
                            Salary = e.Salary,
                            JoiningDate = e.JoiningDate,
                            NomDepartement = d.Name
                        };
            return View(query.ToList());
        }

        // GET: EmployeeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EmployeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Edit/5
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

        // GET: EmployeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController1/Delete/5
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
