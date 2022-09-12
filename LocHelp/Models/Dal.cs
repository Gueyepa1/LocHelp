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
            this._bddContext = new BddContext();
        }
        public void Dispose()
        {
            this._bddContext.Dispose();
        }

        public void CreerPrestationDeService(TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath, int UserId, int id = 0)
        {
            PrestationDeService prestationDeService = new PrestationDeService { TypeDeService = typeDeService, TypeAnnonce = typeAnnonce, DateDeDebut = dateDeDebut, DateDeFin = dateDeFin, Description = description, ImagePath = imagePath, UtilisateurId = UserId };
            if (id != 0)
            {
                prestationDeService.Id = id;
            }
            this._bddContext.PrestationDeServices.Add(prestationDeService);
            this._bddContext.SaveChanges();
        }
        public List<PrestationDeService> ObtientToutesLesPrestationsDeService()
        {
            List<PrestationDeService> listePrestation = this._bddContext.PrestationDeServices.ToList();
            return listePrestation;
        }
        public void  SupprimerPrestationDeService(int id)
        {
            PrestationDeService prestationdelete = this._bddContext.PrestationDeServices.Find(id);
            this._bddContext.PrestationDeServices.Remove(prestationdelete);
            this._bddContext.SaveChanges();
        }

        public void ModifierPrestationDeService(int id, TypeDeService typeDeService, TypeAnnonce typeAnnonce, DateTime dateDeDebut, DateTime dateDeFin, int tarif, string description, string imagePath, Role role = Role.Locataire)
        {
            PrestationDeService prestationUpdate = this._bddContext.PrestationDeServices.Find(id);
            if (prestationUpdate != null)
            {
                prestationUpdate.TypeDeService = typeDeService;
                prestationUpdate.TypeAnnonce = typeAnnonce;
                prestationUpdate.DateDeDebut = dateDeDebut;
                prestationUpdate.DateDeFin = dateDeFin;
                prestationUpdate.Tarif = tarif;
                prestationUpdate.Description = description;
                prestationUpdate.ImagePath = imagePath;
                this._bddContext.SaveChanges();
            }
        }

        public bool PrestationExiste(string description)
        {

            return _bddContext.PrestationDeServices.ToList().Any(prestationDeService=> string.Compare(prestationDeService.Description,description, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public void DeleteCreateDatabase()
        {
            this._bddContext.Database.EnsureDeleted();
            this._bddContext.Database.EnsureCreated();
        }
        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return _bddContext.Utilisateur.Include(u => u.ContactInfos).Include(u => u.PersonnelInfos).Include(u => u.ContactInfos.AdresseContact).Include(u => u.Compte).ToList();
        }

        public Utilisateur ObtenirUtilisateur(int id)
        {
            return this._bddContext.Utilisateur.Include(u => u.ContactInfos).Include(u => u.PersonnelInfos).Include(u => u.ContactInfos.AdresseContact).Include(u => u.Compte).FirstOrDefault(u => u.Id == id);
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
<<<<<<< HEAD
        public Utilisateur CreerUtilisateur( string pseudo, string statut, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune,string identifiant,string motDepasse, Role role = Role.Locataire)
        {
            Profil profil = new Profil() { Pseudo = pseudo, Statut = statut };
            PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
            AdresseContact adresseContact = new AdresseContact() { NumeroDeLaRue = numeroRue, NomDeLaRue = nomRue, CodePostal = codePostal, Commune = commune };
            ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTel, AdresseMail = adresseMail, AdresseContact = adresseContact };
            Compte compte = new Compte() { Identifiant = identifiant, MotDePasse = motDepasse };
            Utilisateur utilisateur = new Utilisateur() {Role=role, Profil = profil, PersonnelInfos = personnelInfos, ContactInfos = contactInfos };
            _bddContext.Utilisateur.Add(utilisateur);
            _bddContext.SaveChanges();

            return utilisateur;
        }
        //public void ModifierUtilisateur(int id, string pseudo, string prenom, string adressemail)
=======
        //public Utilisateur CreerUtilisateur( string pseudo, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTel, string adresseMail, int numeroRue, string nomRue, int codePostal, string commune,string identifiant,string motDepasse, Role role = Role.Locataire)
>>>>>>> 8f7654d32d8ef8196010fd65e0b59cf46643052b
        //{
        //    _bddContext.SaveChanges();
        //    PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
        //    _bddContext.PersonnelInfos.Add(personnelInfos);
        //    _bddContext.SaveChanges();
        //    AdresseContact adresseContact = new AdresseContact() { NumeroDeLaRue = numeroRue, NomDeLaRue = nomRue, CodePostal = codePostal, Commune = commune };
        //    _bddContext.AdresseContact.Add(adresseContact);
        //    _bddContext.SaveChanges();
        //    ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTel, AdresseMail = adresseMail, AdresseContact = adresseContact };
        //    _bddContext.ContactInfos.Add(contactInfos);
        //    _bddContext.SaveChanges();
        //    Compte compte = new Compte() { Identifiant = identifiant, MotDePasse = motDepasse };
        //    _bddContext.Compte.Add(compte);
        //    _bddContext.SaveChanges();
        //    Utilisateur utilisateur = new Utilisateur() {Role=role, Pseudo = pseudo, PersonnelInfos = personnelInfos, ContactInfos = contactInfos };
        //    _bddContext.Utilisateur.Add(utilisateur);
        //    _bddContext.SaveChanges();

        //    return utilisateur;
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

        public List<Reglement> ObtientTousLesReglements()
        {
            List<Reglement> listeReglements = this._bddContext.Reglement.ToList();
            return listeReglements;
        }

        public void CreerReglement(string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement, TypeCharges typeCharges, TypeReglement typeReglement, int id = 0)
        {
            Reglement reglementToAdd = new Reglement { NomDestinataire = nomDestinataire, PrenomDestinataire = prenomDestinataire, DateEmission = dateEmission, SoldeAPayer = soldeAPayer, Reference = reference, NumeroAppartement = numeroAppartement, TypeCharges = typeCharges, TypeReglement = typeReglement };
            if (id != 0)
            {
                reglementToAdd.Id = id;
            }
            this._bddContext.Reglement.Add(reglementToAdd);
            this._bddContext.SaveChanges();
        }

        public void ModifierReglement(int id, string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement, TypeCharges typeCharges, TypeReglement typeReglement)
        {
            Reglement reglementToUpdate = this._bddContext.Reglement.Find(id);
            if (reglementToUpdate != null)
            {
                reglementToUpdate.TypeCharges = typeCharges;
                reglementToUpdate.TypeReglement = typeReglement;
                reglementToUpdate.NomDestinataire = nomDestinataire;
                reglementToUpdate.PrenomDestinataire = prenomDestinataire;
                reglementToUpdate.DateEmission = dateEmission;
                reglementToUpdate.DateDeReglement = dateDeReglement;
                reglementToUpdate.SoldeAPayer = soldeAPayer;
                reglementToUpdate.Reference = reference;
                reglementToUpdate.NumeroAppartement = numeroAppartement;
                this._bddContext.SaveChanges();
            }
        }

        public void SupprimerReglement(int id)
        {
            Reglement reglementToDelete = this._bddContext.Reglement.Find(id);
            this._bddContext.Reglement.Remove(reglementToDelete);
            this._bddContext.SaveChanges();
        }

        public void SupprimerReglement(string nomDestinataire, string prenomDestinataire, DateTime dateEmission, DateTime dateDeReglement, int soldeAPayer, int reference, int numeroAppartement)
        {
            Reglement reglementToDelete = this._bddContext.Reglement.Where(r => r.NomDestinataire == nomDestinataire && r.PrenomDestinataire == prenomDestinataire && r.SoldeAPayer == soldeAPayer && r.DateDeReglement == dateDeReglement).FirstOrDefault();
            if (reglementToDelete != null)
            {
                this._bddContext.Reglement.Remove(reglementToDelete);
                this._bddContext.SaveChanges();
            }
        }

        public bool ReglementExiste(string nomDestinataire)
        {
            return _bddContext.Reglement.ToList().Any(reglement => string.Compare(reglement.NomDestinataire, nomDestinataire, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public Utilisateur CreerUtilisateur(string pseudo, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string imagePath, string identifiant, string motDepasse, Role role = Role.Locataire)
        {
            PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom, DateDeNaissance = dateDeNaissance };
            ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTelephone, AdresseMail = adresseMail };
            Compte compte = new Compte() { Identifiant = identifiant, MotDePasse = motDepasse };
            Utilisateur utilisateur = new Utilisateur() { Pseudo = pseudo, PersonnelInfos = personnelInfos, ContactInfos = contactInfos, Compte = compte, ImagePath = imagePath, Role = role };
            string password = EncodeMD5(motDepasse);
            this._bddContext.Utilisateur.Add(utilisateur);
            this._bddContext.SaveChanges();
            return utilisateur;
        }

        public void ModifierUtilisateur(int id, string pseudo, string nom, string prenom, DateTime dateDeNaissance, string numeroDeTelephone, string adresseMail, int numeroDeLaRue, string nomDeLaRue, int codePostal, string commune, string imagePath, string identifiant, string motDepasse)
        {
            PersonnelInfos personnelInfos = new PersonnelInfos() { Nom = nom, Prenom = prenom };
            ContactInfos contactInfos = new ContactInfos() { NumeroDeTelephone = numeroDeTelephone, AdresseMail = adresseMail };
            Compte compte = new Compte() { Identifiant = identifiant, MotDePasse = motDepasse };

            Utilisateur utilisateur = _bddContext.Utilisateur.Find(id);

            if (utilisateur != null)
            {
                utilisateur.Pseudo = pseudo;
                utilisateur.PersonnelInfos = personnelInfos;
                utilisateur.ContactInfos = contactInfos;
                utilisateur.Compte = compte;
                _bddContext.SaveChanges();
            }
        }
    }
}

