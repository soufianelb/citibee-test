using citibee_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Dto
{
    public class GebruikerDto
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
 
        public string Email { get; set; }
     
        public  ICollection<GereserveerdeItem> GereserveerdeItem { get; set; }
    }
}
