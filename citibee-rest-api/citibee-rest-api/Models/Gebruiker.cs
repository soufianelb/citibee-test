using System;
using System.Collections.Generic;

namespace citibee_rest_api.Models
{
    public partial class Gebruiker
    {
        public Gebruiker()
        {
            GereserveerdeItem = new HashSet<GereserveerdeItem>();
        }

        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }

        public virtual ICollection<GereserveerdeItem> GereserveerdeItem { get; set; }
    }
}
