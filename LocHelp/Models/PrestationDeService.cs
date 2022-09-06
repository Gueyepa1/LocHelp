namespace LocHelp.Models
{
    public class PrestationDeService
    {
        public int Id { get; set; }
        public int? TypeDeService { get; set; }
        public virtual TypeDeService TypeDeServices { get; set; }
        public int? TypeEvenement { get; set; }
        public virtual TypeEvenement TypeEvenements { get; set; }
        public int? TypeEquipement { get; set; }
        public virtual TypeEquipement TypeEquipements { get; set; }

    }
}
