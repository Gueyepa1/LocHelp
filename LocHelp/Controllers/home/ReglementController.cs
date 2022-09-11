using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LocHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocHelp.Controllers.home
{
    public class ReglementController : Controller
    {
        private IDal dal;
        private IWebHostEnvironment _webEnvironment;
        public ReglementController(IWebHostEnvironment environment)
        {
            _webEnvironment = environment;
            this.dal = new Dal();
        }

        public IActionResult Reglement()
        {
            List<Reglement> listeReglements = dal.ObtientTousLesReglements();

            return View(listeReglements);
        }

        public ActionResult CreerReglement()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerReglement(Reglement reglement)
        {
            if (dal.UtilisateurExiste(reglement.NomDestinataire))
            {
                ModelState.AddModelError("NomDestinataire", "Ce destinataire existe déjà");
                return View(reglement);
            }
            if (!ModelState.IsValid)
                return View(reglement);
            dal.CreerReglement(reglement.NomDestinataire, reglement.PrenomDestinataire, reglement.DateEmission, reglement.DateDeReglement, reglement.SoldeAPayer, reglement.Reference, reglement.NumeroAppartement, reglement.TypeCharges, reglement.TypeReglement);
            return RedirectToAction("Index");
        }


        public ActionResult ModifierReglement(int? id)
        {
            if (id.HasValue)
            {
                Reglement reglement = dal.ObtientTousLesReglements().FirstOrDefault(r => r.Id == id.Value);
                if (reglement == null)
                    return View("Error");
                return View(reglement);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult ModifierReglement(Reglement reglement)
        {
            if (!ModelState.IsValid)
                return View(reglement);
            dal.ModifierReglement(reglement.Id, reglement.NomDestinataire, reglement.PrenomDestinataire, reglement.DateEmission, reglement.DateDeReglement, reglement.SoldeAPayer, reglement.Reference, reglement.NumeroAppartement, reglement.TypeCharges, reglement.TypeReglement);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Supprimer(int id)
        {
            dal.SupprimerReglement(id);
            return RedirectToAction("Index");
        }

        public ActionResult ReglerLoyer(int? id)
        {
            int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Reglement reglement = dal.ObtientTousLesReglements().FirstOrDefault(r => r.Id == id.Value);
            ViewData["Prix"] = reglement.SoldeAPayer;
            return View();
        }

        public ActionResult ReglerCharges(int? id)
        {
            int UserId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Reglement reglement = dal.ObtientTousLesReglements().FirstOrDefault(r => r.Id == id.Value);
            ViewData["Prix"] = reglement.SoldeAPayer;
            return View();
        }
    }
}

