using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gestion_Employes.Areas.Identity.Data;
using GestionEmployes.Models.repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Employes.Models
{
    public class Gestion_EmployesContext : IdentityDbContext<Gestion_EmployesUser>
    {
        public Gestion_EmployesContext(DbContextOptions<Gestion_EmployesContext> options)
            : base(options)
        {
        }
        public DbSet<Employe> employe { get; set; }
        public DbSet<Equipe> equipe { get; set; }
        public DbSet<Projet> projet { get; set; }
        public DbSet<Categorie> categorie { get; set; }
        public DbSet<Historique> historique { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
