
using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class ContactInfos
    {
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string NumeroDeTelephone { get; set; }
        [MaxLength(50)]
        public string AdresseMail { get; set; }
        public int? AdresseContactId { get; set; }
        public virtual AdresseContact AdresseContact { get; set; }


    }
}
