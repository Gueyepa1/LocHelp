using LocHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;

namespace LocHelp.Controllers.home
{
    public class UtilisateurController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnvironment;
        public UtilisateurController(IWebHostEnvironment environment)
        {
            _webEnvironment = environment;
            this.dal = new Dal();
        }
        public ActionResult Modifier()
        {
            int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (UserId != 0)
            {
                Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().FirstOrDefault(r => r.Id == UserId);
                if (utilisateur == null)
                    return View("Error");
                return View(utilisateur);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Modifier(Utilisateur utilisateur)
        {
            int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (!ModelState.IsValid)
                return View(utilisateur);


            //if (utilisateur.Image != null)
            //{
            //    if (utilisateur.Image.Length != 0)
            //    {
            //        string uploads = Path.Combine(_webEnvironment.WebRootPath, "images");
            //        string filPath = Path.Combine(uploads, utilisateur.Image.FileName);
            //        using (Stream fileStream = new FileStream(filPath, FileMode.Create))
            //        {
            //            utilisateur.Image.CopyTo(fileStream);
            //        }
            //        dal.ModifierUtilisateur(utilisateur.Id, utilisateur.Pseudo, utilisateur.PersonnelInfos.Nom, utilisateur.PersonnelInfos.Prenom, utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.ContactInfos.NumeroDeTelephone, utilisateur.ContactInfos.AdresseMail, utilisateur.NumeroAppartement, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, "/images/" + utilisateur.Image.FileName, utilisateur.Role);
            //    }
            //}
            //else
            //{
                dal.ModifierUtilisateur(utilisateur.Id, utilisateur.Pseudo, utilisateur.PersonnelInfos.Nom, utilisateur.PersonnelInfos.Prenom, utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.ContactInfos.NumeroDeTelephone, utilisateur.ContactInfos.AdresseMail, utilisateur.NumeroAppartement, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, utilisateur.Role);
            //}
            return RedirectToAction("Index");

        }

    }
}
