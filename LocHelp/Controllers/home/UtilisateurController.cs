using LocHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LocHelp.Controllers.home
{
    public class UtilisateurController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnv;

        public UtilisateurController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
        }

        [HttpGet]
        public IActionResult ModifierUtilisateur(int id)
        {
            if (id != 0)
            {
                using (Dal dal = new Dal())
                {
                    Utilisateur utilisateur = dal.ObtientTousLesUtilisateurs().Where(r => r.Id == id).FirstOrDefault();
                    if (utilisateur == null)
                    {
                        return View("Error");
                    }
                    return View(utilisateur);
                }
            }
            return View("Error");
        }
        [HttpPost]
        public IActionResult ModifierUtilisateur(Utilisateur utilisateur)
        {
          

            if (utilisateur.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierUtilisateur( utilisateur);
                    return RedirectToAction("ModifierUtilisateur", new { @id = utilisateur.Id });
                }
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Locataire")]
        public ActionResult ModifierPrestation(int? id)
        {
            if (id.HasValue)
            {
                PrestationDeService prestationDeService = dal.ObtientToutesLesPrestationsDeServices().FirstOrDefault(r => r.Id == id.Value);
                if (prestationDeService == null)
                    return View("Error");

                //string fileName = sejour.ImagePath.Split('/').Last();
                //string uploads = Path.Combine(_webEnv.WebRootPath, "images");
                //string filePath = Path.Combine(uploads, fileName);
                //using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    var file = new FormFile(fileStream, 0, fileStream.Length, null, fileName);
                //    sejour.Image = file;

                //}
                return View(prestationDeService);
            }
            else
                return NotFound();
        }
        [Authorize(Roles = "Locataire")]

        [HttpPost]
        public ActionResult ModifierPrestation(PrestationDeService prestationDeService)
        {
            if (!ModelState.IsValid)
                return View(prestationDeService);

            if (prestationDeService.Image != null)
            {
                if (prestationDeService.Image.Length != 0)
                {
                    string uploads = Path.Combine(_webEnv.WebRootPath, "images");
                    string filePath = Path.Combine(uploads, prestationDeService.Image.FileName);
                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        prestationDeService.Image.CopyTo(fileStream);
                    }
                    dal.ModifierPrestationDeService(prestationDeService.Id, prestationDeService.TypeDeService, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, "/images/" + prestationDeService.Image.FileName);
                }
            }
            else
            {
                dal.ModifierPrestationDeService(prestationDeService.Id, prestationDeService.TypeDeService, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, prestationDeService.ImagePath);
            }
            return RedirectToAction("Prestation");
        }

        [Authorize(Roles = "Locataire")]
        public ActionResult Supprimer(int id)
        {
            dal.SupprimerPrestationDeService(id);
            return RedirectToAction("Index");
        }
        public ActionResult Prestation()
        {
            List<PrestationDeService> listePrestations = dal.ObtientToutesLesPrestationsDeServices();
            return View(listePrestations);
        }

        public ActionResult CreerPrestation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerPrestation(PrestationDeService prestationDeService)
        {
            if (dal.PrestationExiste(prestationDeService.Description))
            {
                ModelState.AddModelError("Description", "Cette description existe déjà");
                return View(prestationDeService);
            }
            if (!ModelState.IsValid)
                return View(prestationDeService);
            dal.CreerPrestationDeService(prestationDeService.TypeDeService, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description);
            return RedirectToAction("Prestation");
        }

    }
}
