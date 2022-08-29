using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEmployes.Models.repositories
{
    public class Projet
    {
        public int Id { get; set; }
        [Required]
        
        public string Nom_projet { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }
        public string Etat { get; set; }
        public int IdEquipe { get; set; }
        [ForeignKey(nameof(IdEquipe))]
        public virtual Equipe Equipe { get; set; }
    }
}
