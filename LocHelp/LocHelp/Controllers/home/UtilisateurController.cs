using LocHelp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LocHelp.Controllers.home
{
    public class UtilisateurController : Controller
    {
       
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


    }
}
