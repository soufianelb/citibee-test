using System;
using System.Collections.Generic;

namespace citibee_rest_api.Models
{
    public partial class ReserveringItem
    {
        public ReserveringItem()
        {
            GereserveerdeItem = new HashSet<GereserveerdeItem>();
        }

        public int Id { get; set; }
        public string Barcode { get; set; }
        public int ItemTypeId { get; set; }
        public int ParkeergarageId { get; set; }
        public string Parkingnr { get; set; }
        public virtual ReserveringItemType ItemType { get; set; }
        public virtual Parkeergarage Parkeergarage { get; set; }
        public virtual ICollection<GereserveerdeItem> GereserveerdeItem { get; set; }
    }
}
