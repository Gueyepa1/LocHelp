using Microsoft.EntityFrameworkCore;
using System;

namespace LocHelp.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Reglement> Reglement { get; set; }
        public DbSet<PersonnelInfos> PersonnelInfos { get; set; }
        public DbSet<ContactInfos> ContactInfos { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<PrestationDeService> PrestationDeServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;user id=root;password=Mamadou1.;database=Projet2Groupe2");

        }
        public void InitializeDb()
        {

            PersonnelInfos personnelInfos1 = new PersonnelInfos() { Nom = "GUEYE", Prenom = "Papa", DateDeNaissance = new DateTime(2000, 09, 08, 15, 45, 54) };
            ContactInfos contactInfos1 = new ContactInfos() { NumeroDeTelephone = "0671358282", AdresseMail = "papa@gmail.com" };
            Compte compte1 = new Compte() { Identifiant = "gueypelo1", MotDePasse = Dal.EncodeMD5("gyetef")};
  
            PersonnelInfos personnelInfos2 = new PersonnelInfos() { Nom = "MBA", Prenom = "Arsene", DateDeNaissance = new DateTime(2002, 09, 08, 15, 45, 54) };
            ContactInfos contactInfos2 = new ContactInfos() { NumeroDeTelephone = "0698379899", AdresseMail = "arsene@gmail.com" };
            Compte compte2 = new Compte() { Identifiant = "dougmba02", MotDePasse =Dal.EncodeMD5 ("mba2002apt2")};

            PersonnelInfos personnelInfos3 = new PersonnelInfos() { Nom = "ElHadj", Prenom = "Hideya", DateDeNaissance = new DateTime(2001, 07, 06, 15, 45, 54) };
            ContactInfos contactInfos3 = new ContactInfos() { NumeroDeTelephone = "0698379898", AdresseMail = "hideya@gmail.com" };
            Compte compte3 = new Compte() { Identifiant = "hydel01", MotDePasse = Dal.EncodeMD5("hydel01") };



            Utilisateur utilisateur1 = new Utilisateur() { Pseudo = "gueyepa", NumeroAppartement = 801, PersonnelInfos = personnelInfos1, ContactInfos = contactInfos1, Compte = compte1, Role = Role.Admin };
            Utilisateur utilisateur2 = new Utilisateur() { Pseudo = "doug", NumeroAppartement = 802, PersonnelInfos = personnelInfos2, ContactInfos = contactInfos2, Compte = compte2, Role = Role.Locataire};
            Utilisateur utilisateur3 = new Utilisateur() { Pseudo = "elhadj12", NumeroAppartement = 803, PersonnelInfos = personnelInfos3, ContactInfos = contactInfos3, Compte = compte3, Role = Role.Proprietaire };
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Utilisateur.AddRange(
               new Utilisateur
               {
                   Id = 1,
                   Pseudo = "gueyepa",
                   NumeroAppartement = 801,
                   ContactInfos = contactInfos1,
                   PersonnelInfos = personnelInfos1,
                   Compte = compte1,
                   Role = Role.Admin


               },
               new Utilisateur
               {
                   Id = 2,
                   Pseudo = "doug",
                   NumeroAppartement = 802,
                   ContactInfos = contactInfos2,
                   PersonnelInfos = personnelInfos2,
                   Compte = compte2,
                   Role = Role.Locataire

               },
               new Utilisateur
               {
                   Id = 3,
                   NumeroAppartement = 803,
                   Pseudo = "elhadj12",
                   ContactInfos = contactInfos3,
                   PersonnelInfos = personnelInfos3,
                   Compte = compte3,
                   Role = Role.Proprietaire

               }
            );
            this.PrestationDeServices.AddRange(
            new PrestationDeService
            {
                Id = 1,
                TypeDeService = TypeDeService.CoursDeSoutien,
                DateDeDebut = DateTime.Now,
                DateDeFin = DateTime.Now,
                Tarif = 15,
                Description = "Je propose les cours de soutien pour les classes: 6ème, 5ème 3ème,, 2nd et Tle S, uniquement les samedis et dimaches",
                ImagePath = "/images/"

            },

                  new PrestationDeService
                  {
                      Id = 2,
                      TypeDeService = TypeDeService.decoration,
                      DateDeDebut = DateTime.Now,
                      DateDeFin = DateTime.Now,
                      Tarif = 50,
                      Description = "Je vous propose une décoration intérieure dans toutes les pièces de votre appartement. je suis licencié en décoration.",
                      ImagePath = "/images/"

                  },
                    new PrestationDeService
                    {
                        Id = 3,
                        TypeDeService = TypeDeService.Cuisine,
                        DateDeDebut = DateTime.Now,
                        DateDeFin = DateTime.Now,
                        Tarif = 0,
                        Description = "Jemets mon matériel de cuisine à la disposition des habitants de l'immeuble.",
                        ImagePath = "/images/"
                    }

                );
            this.Reglement.AddRange(
            new Reglement
            {
                Id = 1,
                TypeCharges = TypeCharges.Loyer,
                NomDestinataire = "ElHadj",
                PrenomDestinataire = "Hideya",
                SoldeAPayer = 810,
                Reference = 12202,
                NumeroAppartement = 01,
                DateEmission = DateTime.Now,
                DateDeReglement = DateTime.Now,

            },

                  new Reglement
                  {
                      Id = 2,
                      TypeCharges = TypeCharges.ChargesAnnuelles,
                      NomDestinataire = "MBA",
                      PrenomDestinataire = "Arsene",
                      SoldeAPayer = 235,
                      Reference = 21532,
                      NumeroAppartement = 02,
                      DateEmission = DateTime.Now,
                      DateDeReglement = DateTime.Now,
                  }
                );
            this.SaveChanges();
         
        }
    }

}