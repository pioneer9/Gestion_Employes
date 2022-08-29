using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GestionEmployes.Models.repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Gestion_Employes.Models;

namespace GestionEquipe.Controllers
{
    public class EquipeController : Controller
    {
        private readonly Gestion_EmployesContext gestionEmployeContext;
        public EquipeController(Gestion_EmployesContext gestionequipeContext)
        {
            this.gestionEmployeContext = gestionequipeContext;
        }
        // GET: equipeController
        public ActionResult Index()
        {
            var equipe = gestionEmployeContext.equipe.Include(x=>x.Employes).ToList();
            return View(equipe);
        }

        // GET: equipeController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListEmplye = ListEmplye();
            return View(gestionEmployeContext.equipe.Find(id));
        }
        List<Employe> ListEmplye()
        {
            var employe = gestionEmployeContext.employe.ToList();
            employe.Insert(0, new Employe { Id = -1,Name="--select Nom--" });

            return employe;
        }
        // GET: equipeController/Create
        public ActionResult Create()
        {
            ViewBag.ListEmplye = ListEmplye();
            return View();
        }


        // POST: equipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe equipe)
        {
            try
            {
                var epml = gestionEmployeContext.employe.Find(equipe.Employes);
                var newEquipe = new Equipe
                {
                    Nom_equipe = equipe.Nom_equipe,
                    Employes = equipe.Employes,

                };
                gestionEmployeContext.equipe.Add(newEquipe);
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public void CreateListEquipe()
        {

            
                var newEquipe = new Equipe
                {
                    
                    
                    

                };
                gestionEmployeContext.equipe.Add(newEquipe);
                gestionEmployeContext.SaveChanges();
          
        }


        // GET: equipeController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.ListEmplye = ListEmplye();
            return View(gestionEmployeContext.equipe.Find(id));
        }

        // POST: equipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Equipe equipe)
        {
            try
            {
                gestionEmployeContext.Entry(equipe).State = EntityState.Modified;
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: equipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gestionEmployeContext.equipe.Find(id));
        }

        // POST: equipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var equipe = gestionEmployeContext.equipe.Find(id);
                gestionEmployeContext.Remove(equipe);
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
