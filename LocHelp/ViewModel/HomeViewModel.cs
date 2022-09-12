using LocHelp.Models;
using System;

namespace LocHelp.ViewModel
{
    public class HomeViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public ContactInfos ContactInfos { get; set; }
        public PersonnelInfos PersonnelInfos { get; set; }

    }
}

