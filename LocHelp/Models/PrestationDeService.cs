using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocHelp.Models
{
    public class PrestationDeService
    {
        public int Id { get; set; }
        public TypeDeService TypeDeService { get; set; }
        //public TypeEvenement TypeEvenement { get; set; }
      
        //public TypeEquipement TypeEquipement { get; set; }
        public DateTime DateDeDebut { get; set; }
        public DateTime DateDeFin { get; set; }
        public int Tarif { get; set; }
        public TypeAnnonce TypeAnnonce { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public int? UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }


    }

    public enum TypeAnnonce
    {
        demande, proposition
    }

    public enum TypeDeService
    {
        Jardinage,
        CoursDeSoutien,
        Menage,
        GardeDEnfant,
        AideALaPersonne, 
        Courses, 
        PlacesDeparking,
        Cuisine,
        decoration,
        Jardin,
        Mecanique,
        Mariage,
        FeteDesVoisins,
        ReunionDesCoprprietaires
    }

    //public enum TypeEquipement
    //{
    //    Cuisine,
    //    decoration,
    //    Jardin,
    //    Mecanique
    //}

    //public enum TypeEvenement
    //{
    //    Mariage,
    //    FeteDesVoisins,
    //    ReunionDesCoprprietaires
    //}
}
