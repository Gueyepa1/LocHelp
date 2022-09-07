﻿using LocHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LocHelp.Controllers.home
{
    public class PrestationDeServiceController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnv;

        public PrestationDeServiceController(IWebHostEnvironment environment)
        {
            _webEnv = environment;
            this.dal = new Dal();
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
                dal.ModifierPrestationDeService(prestationDeService.Id, prestationDeService.TypeDeService, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description,  prestationDeService.ImagePath);
            }
            return RedirectToAction("Prestation");
        }

        [Authorize(Roles = "Locataire")]
        public ActionResult Supprimer(int id)
        {
            dal.SupprimerPrestationDeService(id);
            return RedirectToAction("Index");
        }

    }
}