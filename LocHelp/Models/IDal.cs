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

        Utilisateur CreerUtilisateur( string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune, string identifiant, string motDepasseRole, Role role = Role.Locataire);

       

        // void ModifierUtilisateur(int id, string pseudo, string prenom, string adresseMail);
        void ModifierUtilisateur(Utilisateur utilisateur);
        //void ModifierUtilisateur(int id, string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune);
        public Utilisateur Authentifier(string identifiant, string password);
        bool UtilisateurExiste(string numeroDeTel);
        void SupprimerUtilisateur(int id);

        void CreerPrestationDeService(TypeDeService typeDeService, DateTime dateDeDebut, DateTime dateDeFin, string tarif, string description, int id = 0);
        List<PrestationDeService> ObtientToutesLesPrestationsDeServices();
        void SupprimerPrestationDeService(int id);
        bool PrestationExiste(string description);
        void ModifierPrestationDeService(int id, TypeDeService typeDeService, DateTime dateDeDebut, DateTime dateDeFin, string tarif, string description, string imagePath);


    }
}
