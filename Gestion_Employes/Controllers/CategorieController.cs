using Gestion_Employes.Models;
using GestionEmployes.Models.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestionEmployes.Controllers
{
    public class CategorieController : Controller
    {
        private readonly Gestion_EmployesContext gestionEmployeContext;
        public CategorieController(Gestion_EmployesContext gestionEmployeContext)
        {
            this.gestionEmployeContext = gestionEmployeContext;
        }
        // GET: CategorieController
        public ActionResult Index()
        {
            var cat = gestionEmployeContext.categorie.ToList();
            return View(cat);
        }

        // GET: CategorieController/Details/5
        public ActionResult Details(int id)
        {
            return View(gestionEmployeContext.categorie.Find(id));
        }
        List<Employe> ListEmplye()
        {
            var employe = gestionEmployeContext.employe.ToList();
            employe.Insert(0, new Employe { Id = -1, Name = "--select Nom--" });

            return employe;
        }
        // GET: CategorieController/Create
        public ActionResult Create()
        {
            ViewBag.Employe = ListEmplye();
            return View();
        }

        // POST: CategorieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorie categorie)
        {
            try
            {
                gestionEmployeContext.categorie.Add(categorie);
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(gestionEmployeContext.categorie.Find(id));
        }

        // POST: CategorieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categorie categorie)
        {
            try
            {
                gestionEmployeContext.Entry(categorie).State = EntityState.Modified;
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategorieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gestionEmployeContext.categorie.Find(id));
        }

        // POST: CategorieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var cat = gestionEmployeContext.categorie.Find(id);
                gestionEmployeContext.Remove(cat);
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
