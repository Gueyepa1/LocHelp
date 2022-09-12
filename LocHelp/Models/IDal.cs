using System;
using System.Collections.Generic;

namespace LocHelp.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<Utilisateur> ObtientTousLesUtilisateurs();
        Utilisateur ObtenirUtilisateur(string idStr);
        Utilisateur ObtenirUtilisateur(int id);

        Utilisateur CreerUtilisateur( string pseudo, string nom, string prenom, DateTime dateDeNaissance, string NumeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string imagePath, string identifiant, string motDepasse, Role role = Role.Locataire);

       void SupprimerUtilisateur(int id);
        bool UtilisateurExiste(string numeroDeTelephone);

        // void ModifierUtilisateur(int id, string pseudo, string prenom, string adresseMail);
        void ModifierUtilisateur(Utilisateur utilisateur);
        void ModifierUtilisateur(int id, string pseudo, string nom, string prenom, DateTime dateDeNaissance, string NumeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string imagePath, string identifiant, string motDepasse);
        public Utilisateur Authentifier(string identifiant, string password);


        void CreerPrestationDeService(TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath, int UserId, int id = 0);
        List<PrestationDeService> ObtientToutesLesPrestationsDeService();
        void SupprimerPrestationDeService(int id);
        bool PrestationExiste(string description);
        void ModifierPrestationDeService(int id, TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath,Role role=Role.Locataire);


        List<Reglement> ObtientTousLesReglements();
        void ModifierReglement(int id, string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement, TypeCharges typeCharges, TypeReglement typeReglement);
        void SupprimerReglement(int id);
        void SupprimerReglement(string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement);
        bool ReglementExiste(string nomDestinataire);
        void CreerReglement(string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement, TypeCharges typeCharges, TypeReglement typeReglement, int id = 0);
    }
}
