using System;
using System.Collections.Generic;

namespace citibee_rest_api.Models
{
    public partial class ReserveringItemType
    {
        public ReserveringItemType()
        {
            ReserveringItem = new HashSet<ReserveringItem>();
        }

        public int Id { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<ReserveringItem> ReserveringItem { get; set; }
    }
}
