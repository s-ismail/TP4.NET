using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prog.NETTp4.Models;

namespace Prog.NETTp4.Controllers
{
    public class DepartementController : Controller
    {
        private readonly Tp4CompanyDbContext context;

        public DepartementController(Tp4CompanyDbContext context)
        {
            this.context = context;
        }
        // GET: DepartementController
        public ActionResult Index()
        {
            return View(context.Departements.ToList());
        }

        // GET: DepartementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departement departement)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(context.Departements.Where(d => d.Name == departement.Name).Any())
                    {
                        ModelState.AddModelError("", "Le departement existe");
                        return View(departement);
                    }context.Departements.Add(departement);
                    context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }return View(departement);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartementController/Edit/5
        public ActionResult Edit(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View(departement);
        }

        // POST: DepartementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Departement departement)
        {
            try
            {
                Departement depart = context.Departements.Find(id);
                if (depart != null)
                {
                    depart.Name = departement.Name;
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }ModelState.AddModelError("", "Problème");
                return View(departement);
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartementController/Delete/5
        public ActionResult Delete(int id)
        {
            Departement departement = context.Departements.Find(id);
            return View();
        }

        // POST: DepartementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Departement departement)
        {
            try
            {
                context.Departements.Remove(departement);
                context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
