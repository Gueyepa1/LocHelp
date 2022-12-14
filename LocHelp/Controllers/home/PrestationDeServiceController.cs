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
            List<PrestationDeService> listePrestations = dal.ObtientToutesLesPrestationsDeService();
            return View(listePrestations);
        }
        public ActionResult CreerPrestation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreerPrestation(PrestationDeService prestationDeService)
        {

            int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (dal.PrestationExiste(prestationDeService.Description))
            {
                ModelState.AddModelError("Description", "Cette prestation existe déjà");
                return View(prestationDeService);
            }
            //if (!ModelState.IsValid)
            //    return View(prestationDeServiceToAdd);
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
                    dal.CreerPrestationDeService(prestationDeService.TypeDeService, prestationDeService.TypeAnnonce, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, "/images/" + prestationDeService.Image.FileName, UserId);
                }
            }
            else
            {
                dal.CreerPrestationDeService(prestationDeService.TypeDeService, prestationDeService.TypeAnnonce, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, prestationDeService.ImagePath, UserId);
            }
            return RedirectToAction("prestation");

        }

       
        public ActionResult ModifierPrestation(int? id)
        {
            if (id.HasValue)
            {
                PrestationDeService prestationDeService = dal.ObtientToutesLesPrestationsDeService().FirstOrDefault(r => r.Id == id.Value);
                if (prestationDeService == null)
                    return View("Error");
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

                    dal.ModifierPrestationDeService(prestationDeService.Id, prestationDeService.TypeDeService, prestationDeService.TypeAnnonce, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, "/images/" + prestationDeService.Image.FileName);

                }
            }
            else
            {
                dal.ModifierPrestationDeService(prestationDeService.Id, prestationDeService.TypeDeService, prestationDeService.TypeAnnonce, prestationDeService.DateDeDebut, prestationDeService.DateDeFin, prestationDeService.Tarif, prestationDeService.Description, prestationDeService.ImagePath);

            }
            return RedirectToAction("Prestation");
        }

        public ActionResult PayerPrestation(int? id)
        {
            PrestationDeService prestation = dal.ObtientToutesLesPrestationsDeService().FirstOrDefault(r => r.Id == id.Value);
            ViewData["Prix"] = prestation.Tarif;
            return View();
        }

        public ActionResult Supprimer(int id)
        {
            dal.SupprimerPrestationDeService(id);
            return RedirectToAction("Index");
        }

        public ActionResult ReserverPrestation()
        {
            return View();
        }

        public ActionResult AccepterPrestation()
        {
            return View();
        }

    }
}
