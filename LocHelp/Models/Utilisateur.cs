using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocHelp.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Pseudo { get; set; }

        public int? ContactInfosId { get; set; }
        public virtual ContactInfos ContactInfos { get; set; }

        public int NumeroAppartement { get; set; }

        public int? PersonnelInfosId { get; set; }
        public virtual PersonnelInfos PersonnelInfos { get; set; }

        public int? CompteId { get; set; }

        public virtual Compte Compte { get; set; }
        public Role Role { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }


    }
    public enum Role
    {
        Admin,
        Locataire,
        Proprietaire
    }
}