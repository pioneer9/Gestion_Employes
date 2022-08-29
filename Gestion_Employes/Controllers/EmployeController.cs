using Gestion_Employes.Models;
using GestionEmployes.Models.repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace GestionEmployes.Controllers
{
    public class EmployeController : Controller
    {
        private readonly Gestion_EmployesContext gestionEmployeContext;
        [System.Obsolete]
        private readonly IHostingEnvironment hosting;

        [System.Obsolete]
        public EmployeController(Gestion_EmployesContext gestionEmployeContext,
            IHostingEnvironment hosting)
        {
            this.gestionEmployeContext = gestionEmployeContext;
            this.hosting = hosting;
        }
        // GET: EmployeController
        public ActionResult Index()
        { 
             var user = gestionEmployeContext.employe.Include(x=>x.Categorie).Include(x => x.Equipe).ToList();
             return View(user);
        }
        
        // GET: EmployeController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListCategories = ListCategories();
            return View(gestionEmployeContext.employe.Find(id));
        }
        List<Categorie> ListCategories()
        {
            var categories = gestionEmployeContext.categorie.ToList();
            categories.Insert(0, new Categorie { Id = -1, Fonctionnalite = "--select fonctionnalite--" });

            return categories;
        }
        public List<Equipe> ListEquipe()
        {
            var employe = gestionEmployeContext.equipe.ToList();
            employe.Insert(0, new Equipe { Id = -1, Nom_equipe = "--select Nom de equipe--" });

            return employe;
        }
        //Get list Equipe

        //public JsonResult GetEquipe()
        //{
        //    var equipe = gestionEmployeContext.equipe.ToList();
        //    return Json(equipe);
        //}
        public JsonResult GetEquipe(string id)
        {
            List<Equipe> equipe = new List<Equipe>();
              equipe = gestionEmployeContext.equipe.ToList();
            return Json(equipe);
        }

        // Get categorie
        //public List<Categorie> GETCAT()
        //{

        //    return ListCategories();
        //}



        // GET: EmployeController/Create
        public ActionResult Create()
        {
            ViewBag.ListCategories = ListCategories();
            ViewBag.ListEquipe = ListEquipe();
            return View();
        }
        

        // POST: EmployeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Obsolete]
        public ActionResult Create(Employe employe)
        {
            try
            {
                string fileName = string.Empty;
                if (employe.fILE != null)
                {
                    string upl = Path.Combine(hosting.WebRootPath, "uploads");
                    fileName = employe.fILE.FileName;
                    string fullPath = Path.Combine(upl, fileName);
                    employe.fILE.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                
                if (employe.Type != "Chef Chantie" && employe.Type != "Ovrier" && employe.Type != "Admin")
                {
                    ViewBag.MsgType = "ereur";
                    ViewBag.ListCategories = ListCategories();
                    return View();
                }else if(employe.Sexe!="Male" && employe.Sexe != "Famele")
                {
                    ViewBag.MsgType = "ereur";
                    return View();
                }
    
                else {
                    var categorie = gestionEmployeContext.categorie.Find(employe.Categorie.Id);
                    var equipe = gestionEmployeContext.equipe.Find(employe.Equipe.Id);


                    var newEploye = new Employe
                    {
                        Name = employe.Name,
                        Prenom = employe.Prenom,
                        Adress = employe.Adress,
                        Tel = employe.Tel,
                        Date_embauche = employe.Date_embauche,
                        CIN = employe.CIN,
                        Sexe = employe.Sexe,
                        Type = employe.Type,
                        Email = employe.Email,
                        Password = employe.Password,
                        salaire = employe.salaire,
                        Image = fileName,
                        Categorie = categorie,
                        idEquipe = employe.idEquipe
                       
                    

                    };
                    gestionEmployeContext.employe.Add(newEploye);
                    gestionEmployeContext.SaveChanges();



                    //var newEquipe = new Equipe
                    //{
                    //    Nom_equipe ="zak",
                    //    Employes = { employe }


                    ////};
                    //gestionEmployeContext.equipe.Add(newEquipe);
                    gestionEmployeContext.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }


            }
            catch
            {
                return View();
            }
        }

       


        // GET: EmployeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListCategories = ListCategories();
            return View(gestionEmployeContext.employe.Find(id));
        }

        // POST: EmployeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Obsolete]
        public ActionResult Edit(Employe employe)
        {
            try
            {
                string fileName = string.Empty;
                if (employe.fILE != null)
                {
                    string upl = Path.Combine(hosting.WebRootPath, "uploads");
                    fileName = employe.fILE.FileName;
                    string fullPath = Path.Combine(upl, fileName);
                    employe.fILE.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                gestionEmployeContext.Entry(employe).State = EntityState.Modified;
                gestionEmployeContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gestionEmployeContext.employe.Find(id));
        }

        // POST: EmployeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                var user = gestionEmployeContext.employe.Find(id);

                foreach(var item in gestionEmployeContext.equipe)
                {
                    if(item.Employes == user)
                    {
                       gestionEmployeContext.Remove(item);
                        //ViewBag.MessageEquipe = "c'est employe deja dans une equipe";
                    }
                }
                gestionEmployeContext.employe.Remove(user);
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
