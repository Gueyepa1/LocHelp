﻿namespace LocHelp.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }

        public int? ContactInfosId { get; set; }
        public virtual ContactInfos ContactInfos { get; set; }

        public int? ProfilId { get; set; }
        public virtual Profil Profil { get; set; }

        public int? PersonnelInfosId { get; set; }
        public virtual PersonnelInfos PersonnelInfos { get; set; }

        public int? CompteId { get; set; }

        public virtual Compte Compte { get; set; }
        public Role Role { get; set; }

    }
    public enum Role
    {
        Admin,
        ReadWrite,
        ReadOnly
    }
}