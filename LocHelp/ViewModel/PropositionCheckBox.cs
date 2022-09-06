using LocHelp.Models;

namespace LocHelp.ViewModel
{
    public class PropositionCheckBox
    {
        public int Id {get; set;}
        public PrestationDeService ChoixDePrestation { get; set; }
        public bool EstSelectionne { get; set; }

    }
}
