using Microsoft.EntityFrameworkCore;
using System;

namespace LocHelp.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Profil> Profil { get; set; }
        public DbSet<PersonnelInfos> PersonnelInfos { get; set; }
        public DbSet<ContactInfos> ContactInfos { get; set; }
        public DbSet<AdresseContact> AdresseContact { get; set; }
        public DbSet<Compte> Compte { get; set; }
        public DbSet<PrestationDeService> PrestationDeServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;user id=root;password=Mamadou1.;database=Projet2Groupe2");

        }
        public void InitializeDb()
        {
            PrestationDeService prestationDeService = new PrestationDeService();
            Profil profil1 = new Profil() { Pseudo = "gueyepa", Statut = "locataire" };
            PersonnelInfos personnelInfos1 = new PersonnelInfos() { Nom = "GUEYE", Prenom = "Papa", DateDeNaissance = new DateTime(2000, 09, 08, 15, 45, 54) };
            AdresseContact adresseContact1 = new AdresseContact() { NumeroDeLaRue = 01,NomDeLaRue = "Rue Guynemer", CodePostal = 76350, Commune = "Oissel" };
            ContactInfos contactInfos1 = new ContactInfos() { NumeroDeTelephone = "0671358282", AdresseMail = "papa@gmail.com", AdresseContact = adresseContact1 };
            Compte compte1 = new Compte() { Identifiant = "gueypelo1", MotDePasse = Dal.EncodeMD5("gyetef")};
            Profil profil2 = new Profil() { Pseudo = "doug", Statut = "locataire" };
            PersonnelInfos personnelInfos2 = new PersonnelInfos() { Nom = "MBA", Prenom = "Arsene", DateDeNaissance = new DateTime(2002, 09, 08, 15, 45, 54) };
            AdresseContact adresseContact2 = new AdresseContact() { NumeroDeLaRue = 15, NomDeLaRue = "Rue Loupin", CodePostal = 49000, Commune = "Angers" };
            ContactInfos contactInfos2 = new ContactInfos() { NumeroDeTelephone = "0698379899", AdresseMail = "arsene@gmail.com", AdresseContact = adresseContact2 };
            Compte compte2 = new Compte() { Identifiant = "dougmba02", MotDePasse =Dal.EncodeMD5 ("mba2002apt2")};
            Utilisateur utilisateur1 = new Utilisateur() { Profil = profil1, PersonnelInfos = personnelInfos1, ContactInfos = contactInfos1, Compte = compte1 };
            Utilisateur utilisateur2 = new Utilisateur() { Profil = profil2, PersonnelInfos = personnelInfos2, ContactInfos = contactInfos2, Compte = compte2 };
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            this.Utilisateur.AddRange(
               new Utilisateur
               {
                   Id = 1,
                   Profil = profil1,
                   ContactInfos = contactInfos1,
                   PersonnelInfos = personnelInfos1,
                   Compte = compte1
               },
               new Utilisateur
               {
                   Id = 2,
                   Profil = profil2,
                   ContactInfos = contactInfos2,
                   PersonnelInfos = personnelInfos2,
                   Compte = compte2
               }
            );
            this.PrestationDeServices.AddRange(
            new PrestationDeService
                {
                    Id=1,
                    TypeDeService=TypeDeService.CoursDeSoutien,
                    DateDeDebut = DateTime.Now,
                    DateDeFin = DateTime.Now,
                    Tarif ="15€",
                    Description="Je propose les cours de soutien pour les classes: 6ème, 5ème 3ème,, 2nd et Tle S, uniquement les samedis et dimaches"

                },
                
                  new PrestationDeService
                  {
                      Id = 2,
                      TypeDeService = TypeDeService.decoration,
                      DateDeDebut = DateTime.Now,
                      DateDeFin = DateTime.Now,
                      Tarif = "50€",
                      Description = "Je vous propose une décoration intérieure dans toutes les pièces de votre appartement. je suis licencié en décoration."

                  },
                    new PrestationDeService
                    {
                        Id = 3,
                        TypeDeService = TypeDeService.Cuisine,
                        DateDeDebut = DateTime.Now,
                        DateDeFin = DateTime.Now,
                        Tarif = "0€",
                        Description = "Jemets mon matériel de cuisine à la disposition des habitants de l'immeuble."

                    }

                );
            this.SaveChanges();
         
        }
    }

}