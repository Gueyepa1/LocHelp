using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class AdresseContact
    {
        public int Id { get; set; }
        public int NumeroDeLaRue { get; set; }
        [MaxLength(20)]
        public string NomDeLaRue { get; set; }
        public int CodePostal { get; set; }
        [MaxLength(20)]
        public string Commune { get; set; }


    }
}
