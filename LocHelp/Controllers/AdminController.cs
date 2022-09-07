using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocHelp.Controllers
{
    public class AdminController : Controller
    {

        private IDal dal;
        private IWebHostEnvironment _webEnvironment;
        public AdminController(IWebHostEnvironment environment)
        {
            _webEnvironment = environment;
            this.dal = new Dal();
        }

        public IActionResult Index()
        {
            List<Utilisateur> listeDesUtilisateurs = dal.ObtientTousLesUtilisateurs();
            return View(listeDesUtilisateurs);
        }
        public IActionResult Creer()
        {
            return View();
        }

        public IActionResult Voir()
        {
            return View();
        }

        public IActionResult Supprimer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creer(Utilisateur utilisateur)
        {
            if (dal.UtilisateurExiste(utilisateur.Profil.Pseudo))
            {
                ModelState.AddModelError("Pseudo", "Ce pseudo existe déjà");
                return View(utilisateur);
            }
            if (!ModelState.IsValid)
                return View(utilisateur);
            dal.CreerUtilisateur(utilisateur.Profil.Pseudo, utilisateur.Profil.Statut, utilisateur.PersonnelInfos.Nom, utilisateur.PersonnelInfos.Prenom, utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.ContactInfos.NumeroDeTelephone, utilisateur.ContactInfos.AdresseMail, utilisateur.ContactInfos.AdresseContact.NumeroDeLaRue, utilisateur.ContactInfos.AdresseContact.NomDeLaRue, utilisateur.ContactInfos.AdresseContact.CodePostal, utilisateur.ContactInfos.AdresseContact.Commune, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, Role.Locataire);
            return RedirectToAction("Index");
        }

        //public ActionResult Modifier(int? id)
        //{
        //    if (id.HasValue)
        //    {
        //        Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().FirstOrDefault(r => r.Id == id.Value);
        //        if (utilisateur == null)
        //            return View("Error");
        //        return View(utilisateur);
        //    }
        //    else
        //        return NotFound();
        //}

        //[HttpPost]
        //public IActionResult Modifier(Utilisateur utilisateur)
        //{
        //    if (!ModelState.IsValid)
        //        return View(utilisateur);


        //    if (utilisateur.Image != null)
        //    {
        //        if (utilisateur.Image.Length != 0)
        //        {
        //            string uploads = Path.Combine(_webEnvironment.WebRootPath, "images");
        //            string filPath = Path.Combine(uploads, utilisateur.Image.FileName);
        //            using (Stream fileStream = new FileStream(filPath, FileMode.Create))
        //            {
        //                utilisateur.Image.CopyTo(fileStream);
        //            }
        //            dal.ModifierUtilisateur(utilisateur.Id, utilisateur.Profil.Pseudo, utilisateur.PersonnelInfos.Nom, utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.PersonnelInfos.Prenom, utilisateur.ContactInfos.NumeroDeTelepehone, utilisateur.ContactInfos.AdresseMail, utilisateur.ContactInfos.AdresseContact.NumeroDeLaRue, utilisateur.ContactInfos.AdresseContact.NomDeLarue, utilisateur.ContactInfos.AdresseContact.CodePostal, utilisateur.ContactInfos.AdresseContact.Commune, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, "/images/" + utilisateur.Image.FileName);
        //        }
        //    }
        //    else
        //    {
        //        dal.ModifierUtilisateur(utilisateur.Id, utilisateur.Profil.Pseudo, utilisateur.PersonnelInfos.Nom, utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.PersonnelInfos.Prenom, utilisateur.ContactInfos.NumeroDeTelepehone, utilisateur.ContactInfos.AdresseMail, utilisateur.ContactInfos.AdresseContact.NumeroDeLaRue, utilisateur.ContactInfos.AdresseContact.NomDeLarue, utilisateur.ContactInfos.AdresseContact.CodePostal, utilisateur.ContactInfos.AdresseContact.Commune, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, utilisateur.ImagePath);
        //    }
        //    return RedirectToAction("Index");

        //}


        [Authorize(Roles = "Locataire")]
        public ActionResult Supprimer(int id)
        {
            dal.SupprimerUtilisateur(id);
            return RedirectToAction("Index");
        }

    }
}

