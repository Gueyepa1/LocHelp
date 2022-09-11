using System;
using System.ComponentModel.DataAnnotations;

namespace LocHelp.Models
{
    public class Reglement
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string NomDestinataire { get; set; }

        [MaxLength(20)]
        public string PrenomDestinataire { get; set; }

        public int Reference { get; set; }

        public int NumeroAppartement { get; set; }

        public DateTime DateDeReglement { get; set; }

        public int SoldeAPayer { get; set; }

        public DateTime DateEmission { get; set; }

        public int? UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }

        public TypeCharges TypeCharges { get; set; }

        public TypeReglement TypeReglement { get; set; }
    }

    public enum TypeCharges
    {
        Loyer, ChargesAnnuelles
    }

    public enum TypeReglement
    {
        CarteBancaire, Paypal, Virement
    }
}
