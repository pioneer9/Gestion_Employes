namespace GestionEmployes.Models.repositories
{
    public class Historique
    {
        public int Id { get; set; }
        public Employe employe { get; set; }
        public Equipe equipe { get; set; }
        public Projet projet { get; set; }


    }
}
