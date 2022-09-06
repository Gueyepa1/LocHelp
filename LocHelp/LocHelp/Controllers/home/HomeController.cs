using LocHelp.Models;
using LocHelp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LocHelp.Controllers.home
{
    [Authorize]
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    Profil profil = new Profil { Pseudo = "Doug", Statut = "Locataire" };
        //    ContactInfos contactInfos = new ContactInfos { NumeroDeTelephone = 02147456, AdresseMail = "doug@gmail.com" };
        //    List<PersonnelInfos> listeUtilisateur = new List<PersonnelInfos>();
        //    PersonnelInfos utilisateur = new PersonnelInfos { Nom = "MBA ANDJEMBE", Prenom = "Arsène Yorick", DateDeNaissance = new DateTime(1983, 04, 13, 00, 00, 00) };
        //    listeUtilisateur.Add(utilisateur);
        //    PersonnelInfos utilisateur2 = new PersonnelInfos { Nom = "GUEYE", Prenom = "Papa Modou", DateDeNaissance = new DateTime(1987, 05, 27, 00, 00, 00) };
        //    listeUtilisateur.Add(utilisateur2);
        //    PersonnelInfos utilisateur3 = new PersonnelInfos { Nom = "EL HADJ", Prenom = "Hideya", DateDeNaissance = new DateTime(1990, 11, 05, 00, 00, 00) };
        //    listeUtilisateur.Add(utilisateur3);
        //    HomeViewModel hvm = new HomeViewModel
        //    {

        //        Message = "Bonjour tout le monde",
        //        Date = DateTime.Now,
        //        Profil = profil,
        //        ContactInfos = contactInfos
        //    };
        //    return View(hvm);
        //}
        //public IActionResult Index()
        // {
        //     List<Utilisateur> utilisateurs = new List<Utilisateur>();
        //     Utilisateur utilisateur1 = new Utilisateur();
        //     utilisateurs.Add(utilisateur1);
        //     Utilisateur utilisateur2 = new Utilisateur();
        //     utilisateurs.Add(utilisateur2);

        //     ViewBag.ListeUtilisateur = utilisateurs;


        //     HomeViewModel hvm = new HomeViewModel
        //     {
        //         Profil 
        //     };
        //     return View(hvm);
        // }
        //}
       
      
        
            private IDal dal;
            public HomeController()
            {
                dal = new Dal();
            }
            public IActionResult Index()
            {
                return View();
            }
        }

   
}
