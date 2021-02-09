using System;
using System.Collections.Generic;

namespace citibee_rest_api.Models
{
    public partial class GereserveerdeItem
    {
        public int Id { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public int GebruikerId { get; set; }
        public int ReserveringItemId { get; set; }

        public virtual Gebruiker Gebruiker { get; set; }
        public virtual ReserveringItem ReserveringItem { get; set; }
    }
}
