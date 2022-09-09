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

       void SupprimerUtilisateur(int id);
        bool UtilisateurExiste(string numeroDeTelephone);

        // void ModifierUtilisateur(int id, string pseudo, string prenom, string adresseMail);
        void ModifierUtilisateur(Utilisateur utilisateur);
        //void ModifierUtilisateur(int id, string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune);
        public Utilisateur Authentifier(string identifiant, string password);


        void CreerPrestationDeService(TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath, int UserId, int id = 0);
        List<PrestationDeService> ObtientToutesLesPrestationsDeServices();
        void SupprimerPrestationDeService(int id);
        bool PrestationExiste(string description);
        void ModifierPrestationDeService(int id, TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath,Role role=Role.Locataire);

    }
}
