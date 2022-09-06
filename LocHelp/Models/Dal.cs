using LocHelp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LocHelp.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }
        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return _bddContext.Utilisateur.Include(u => u.Profil).Include(u => u.ContactInfos).Include(u => u.PersonnelInfos).Include(u => u.ContactInfos.AdresseContact).Include(u => u.Compte).ToList();
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateur.Include(u => u.Profil).Include(u => u.ContactInfos).Include(u => u.PersonnelInfos).Include(u => u.ContactInfos.AdresseContact).Include(u => u.Compte).FirstOrDefault(u => u.Id == id);
        }
        public Utilisateur ObtenirUtilisateur(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.ObtenirUtilisateur(id);
            }
            return null;
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "LocHelp" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public Utilisateur Authentifier(string identifiant, string password)
        {
            string motDePasse = EncodeMD5(password);
            Utilisateur user = this._bddContext.Utilisateur.Include(u=>u.Compte).FirstOrDefault(u => u.Compte.Identifiant == identifiant && u.Compte.MotDePasse == motDePasse);
            return user;
        }
        public Utilisateur CreerUtilisateur( string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune,string identifiant,string motDepasse, Role role = Role.ReadWrite)
        {
            Profil profil = new Profil() { Pseudo = pseudo, Statut = statut };
            _bddContext.Profil.Add(profil);
            _bddContext.SaveChanges();
            PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
            _bddContext.PersonnelInfos.Add(personnelInfos);
            _bddContext.SaveChanges();
            AdresseContact adresseContact = new AdresseContact() { NumeroDeLaRue = numeroRue, NomDeLaRue = nomRue, CodePostal = codePostal, Commune = commune };
            _bddContext.AdresseContact.Add(adresseContact);
            _bddContext.SaveChanges();
            ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTel, AdresseMail = adresseMail, AdresseContact = adresseContact };
            _bddContext.ContactInfos.Add(contactInfos);
            _bddContext.SaveChanges();
            Compte compte = new Compte() { Identifiant = identifiant, MotDePasse = motDepasse };
            _bddContext.Compte.Add(compte);
            _bddContext.SaveChanges();
            Utilisateur utilisateur = new Utilisateur() {Role=role, Profil = profil, PersonnelInfos = personnelInfos, ContactInfos = contactInfos };
            _bddContext.Utilisateur.Add(utilisateur);
            _bddContext.SaveChanges();

            return utilisateur;
        }
        //public void ModifierUtilisateur(int id, string pseudo, string prenom, string adressemail)
        //{
        //    Utilisateur utilisateur = _bddContext.Utilisateur.Find(id);
        //    if (utilisateur != null)
        //    {
        //        utilisateur.Profil.Pseudo = pseudo;
        //        utilisateur.PersonnelInfos.Prenom = prenom;
        //        utilisateur.ContactInfos.AdresseMail = adressemail;
        //        _bddContext.SaveChanges();
        //    }
        //}
        public void ModifierUtilisateur(Utilisateur utilisateur)
        {

            _bddContext.Utilisateur.Update(utilisateur);
            _bddContext.SaveChanges();

        }

        public void SupprimerUtilisateur(int id)
        {
            Utilisateur utilisateurASupprimer = this._bddContext.Utilisateur.Find(id);
            _bddContext.Utilisateur.Update(utilisateurASupprimer);
            _bddContext.SaveChanges();
        }

        public void SupprimerUtilisateur(string pseudo, string nom, DateTime dateDeNaissance, string prenom, string numeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string identifiant, string motDePasse)
        {
            Utilisateur utilisateurASupprimer = this._bddContext.Utilisateur.Where(r => r.PersonnelInfos.Nom == nom && r.PersonnelInfos.Prenom == prenom).FirstOrDefault();
            if (utilisateurASupprimer != null)
            {
                _bddContext.Utilisateur.Update(utilisateurASupprimer);
                _bddContext.SaveChanges();
            }
        }

        public bool UtilisateurExiste(string numeroDeTelephone)
        {
            return _bddContext.Utilisateur.ToList().Any(utilisateur =>
            string.Compare(utilisateur.ContactInfos.NumeroDeTelephone, numeroDeTelephone,
            StringComparison.CurrentCultureIgnoreCase) == 0);
        }
        //public void ModifierUtilisateur(int id, string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune)
        //{
        //    Profil profil = new Profil() { Pseudo = pseudo, Statut = statut };
        //    PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
        //    AdresseContact adresseContact = new AdresseContact() { NumeroDeLaRue = numeroRue, NomDeLaRue = nomRue, CodePostal = codePostal, Commune = commune };
        //    ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTel, AdresseMail = adresseMail, AdresseContact = adresseContact };
        //    //Utilisateur utilisateur = new Utilisateur() { Profil = profil, PersonnelInfos = personnelInfos, ContactInfos = contactInfos };
        //    Utilisateur utilisateur = _bddContext.Utilisateur.Find(id);
        //    if (utilisateur != null)
        //    {

        //        utilisateur.Profil = profil;
        //        utilisateur.PersonnelInfos = personnelInfos;
        //        utilisateur.ContactInfos = contactInfos;
        //        _bddContext.SaveChanges();



        //    }
        //}
    }
}

