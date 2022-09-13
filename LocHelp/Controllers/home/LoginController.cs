using LocHelp.Models;
using LocHelp.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace LocHelp.Controllers.home
{
    public class LoginController : Controller
    {
        private IDal dal;

        public LoginController()
        {
            this.dal = new Dal();
        }



        public ActionResult Index()
        {
            UtilisateurViewModel viewModel = new UtilisateurViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                viewModel.Utilisateur = dal.ObtenirUtilisateur(userId);
                return Redirect("/home/index");
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Utilisateur utilisateur = dal.Authentifier(viewModel.Utilisateur.Compte.Identifiant, viewModel.Utilisateur.Compte.MotDePasse);
                if (utilisateur != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, utilisateur.Compte.Identifiant),
                         new Claim(ClaimTypes.Name, utilisateur.Compte.MotDePasse),
                        new Claim(ClaimTypes.NameIdentifier, utilisateur.Id.ToString()),
                        new Claim(ClaimTypes.Role, utilisateur.Role.ToString()),
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);



                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return Redirect("/");
                }
                ModelState.AddModelError("Utilisateur.Compte.Identifiant", "Prénom et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public ActionResult CreerCompte()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreerCompte(Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                Utilisateur userCreated = dal.CreerUtilisateur(utilisateur.Pseudo, utilisateur.PersonnelInfos.Nom,utilisateur.PersonnelInfos.Prenom,utilisateur.PersonnelInfos.DateDeNaissance, utilisateur.ContactInfos.NumeroDeTelephone , utilisateur.ContactInfos.AdresseMail , utilisateur.NumeroAppartement, utilisateur.Compte.Identifiant, utilisateur.Compte.MotDePasse, utilisateur.Role);

                var userClaims = new List<Claim>()
                    {
                    //    new Claim(ClaimTypes.Name, userCreated.PersonnelInfos.Nom),
                    //    new Claim(ClaimTypes.Name, userCreated.PersonnelInfos.Prenom),
                    //     new Claim(ClaimTypes.Name, userCreated.Pseudo),
                    //    new Claim(ClaimTypes.Name, userCreated.ContactInfos.NumeroDeTelephone),
                    //    new Claim(ClaimTypes.Email, userCreated.ContactInfos.AdresseMail),
                    //    new Claim(ClaimTypes.Name, userCreated.ContactInfos.AdresseContact.NomDeLaRue),
                    //   new Claim(ClaimTypes.Name, userCreated.ContactInfos.AdresseContact.Commune),
                     new Claim(ClaimTypes.Name, userCreated.Compte.Identifiant),
                     new Claim(ClaimTypes.NameIdentifier, userCreated.Id.ToString()),
                     new Claim(ClaimTypes.Role, userCreated.Role.ToString())
                    };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }
            return View(utilisateur);
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
