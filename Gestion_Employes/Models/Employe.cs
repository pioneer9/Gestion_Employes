using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmployes.Models.repositories
{
    public class Employe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        
        [Phone]
        public string Tel { get; set; }
        public DateTime Date_embauche { get; set; }
        [Required]
        
        public string CIN { get; set; }
        [Required]
        public string Sexe { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        [Required]
        public  int salaire { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile fILE { get; set; }
        public virtual Equipe Equipe { get; set; }
        public virtual int idEquipe { get; set; }
        public virtual Categorie Categorie { get; set; }




    }
}
