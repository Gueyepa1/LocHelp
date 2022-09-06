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
        Utilisateur CreerUtilisateur( string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune, string identifiant, string motDepasse, Role role = Role.ReadWrite);
        // void ModifierUtilisateur(int id, string pseudo, string prenom, string adresseMail);
        void ModifierUtilisateur(Utilisateur utilisateur);
        //void ModifierUtilisateur(int id, string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune);
        public Utilisateur Authentifier(string identifiant, string password);
        void SupprimerUtilisateur(int id);
        void SupprimerUtilisateur(string pseudo, string nom, DateTime dateDeNaissance, string prenom, string numeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string identifiant, string motDePasse);
        bool UtilisateurExiste(string numeroDeTelephone);
    }
}
