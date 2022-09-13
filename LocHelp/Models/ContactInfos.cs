
using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class ContactInfos
    {
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        [Display(Name ="Numéro de téléphone")]
        public string NumeroDeTelephone { get; set; }

        [Display(Name = "Adresse mail")]
        [MaxLength(50)]
        public string AdresseMail { get; set; }



    }
}
