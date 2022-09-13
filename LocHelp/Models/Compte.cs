using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class Compte
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string Identifiant { get; set; }

        [Display(Name = "Mot de passe")]
        [Required]
        public string MotDePasse { get; set; }
    }
}
