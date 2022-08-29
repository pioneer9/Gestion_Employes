using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmployes.Models.repositories
{
    public class Equipe
    {
        public int Id { get; set; }
        [Required]
       
        public string Nom_equipe { get; set; }

        public virtual Projet Projet { get; set; }
        public virtual ICollection<Employe> Employes{ get; set; }

    }
}
