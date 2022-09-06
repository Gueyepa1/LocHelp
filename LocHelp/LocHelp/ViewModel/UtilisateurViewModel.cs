using LocHelp.Models;

namespace LocHelp.ViewModel
{
    public class UtilisateurViewModel
    {
       
            public Utilisateur Utilisateur { get; set; }
            public bool Authentifie { get; set; }
        public int CompteId { get; set; }
        public virtual Compte Compte { get; set; }
       
    }
}
