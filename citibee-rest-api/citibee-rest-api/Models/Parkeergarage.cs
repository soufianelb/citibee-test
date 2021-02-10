using System;
using System.Collections.Generic;

namespace citibee_rest_api.Models
{
    public partial class Parkeergarage
    {
        public Parkeergarage()
        {
            ReserveringItem = new HashSet<ReserveringItem>();
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Geolocatie { get; set; }
        public string Adres { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public virtual ICollection<ReserveringItem> ReserveringItem { get; set; }
    }
}
