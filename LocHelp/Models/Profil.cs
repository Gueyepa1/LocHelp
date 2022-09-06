using System;
using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class Profil
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Pseudo { get; set; }
        [MaxLength(20)]
        public string Statut { get; set; }


    }
}
