using LocHelp.Models;

namespace LocHelp.ViewModel
{
    public class PrestationCheckBox
    {
        public int Id {get; set;}
        public PrestationDeService TypeDePrestation { get; set; }
        public bool EstSelectionne { get; set; }

    }
}
