using System;
using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class PersonnelInfos
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Nom { get; set; }
        [MaxLength(20)]
        public string Prenom { get; set; }

        public DateTime DateDeNaissance { get; set; }


    }
}
