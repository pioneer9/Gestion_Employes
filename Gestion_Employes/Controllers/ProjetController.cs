using Gestion_Employes.Models;
using GestionEmployes.Models.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestionEmployes.Controllers
{
    public class ProjetController : Controller
    {
        private readonly Gestion_EmployesContext gestionEmployeContext;
        public ProjetController(Gestion_EmployesContext gestionEmployeContext)
        {
            this.gestionEmployeContext = gestionEmployeContext;
        }
        // GET: ProjetController
        public ActionResult Index()
        {
            var pro = gestionEmployeContext.projet.Include(x=>x.Equipe).ToList();
            return View(pro);
        }

        // GET: ProjetController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListEquipe = ListEquipe();
            return View(gestionEmployeContext.projet.Find(id));
        }
        List<Equipe> ListEquipe()
        {
            var employe = gestionEmployeContext.equipe.ToList();
            employe.Insert(0, new Equipe { Id = -1, Nom_equipe = "--select Nom de equipe--" });

            return employe;
        }

        // GET: ProjetController/Create
        public ActionResult Create()
        {
            ViewBag.ListEquipe = ListEquipe();
            return View();
        }

        // POST: ProjetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projet projet)
        {
            try
            {
                var equipe = gestionEmployeContext.equipe.Find(projet.Equipe);
                var newProjet = new Projet
                {
                   Nom_projet = projet.Nom_projet,
                    Date_debut = projet.Date_debut,
                    Date_fin = projet.Date_fin,
                    Etat = projet.Etat,
                    IdEquipe = projet.IdEquipe,

                };
                gestionEmployeContext.projet.Add(newProjet);
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjetController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListEquipe = ListEquipe();
            return View(gestionEmployeContext.projet.Find(id));
        }

        // POST: ProjetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Projet projet)
        {
            try
            {
                gestionEmployeContext.Entry(projet).State = EntityState.Modified;
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gestionEmployeContext.projet.Find(id));
        }

        // POST: ProjetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var pro = gestionEmployeContext.projet.Find(id);
                gestionEmployeContext.Remove(pro);
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
