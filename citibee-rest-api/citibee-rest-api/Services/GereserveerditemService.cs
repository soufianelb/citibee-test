using citibee_rest_api.Dal;
using citibee_rest_api.Models;
using citibee_rest_api.Zoek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Services
{
    public class GereserveerditemService
    {
        private readonly CitibeeContext _citibeeContext;

        public GereserveerditemService(CitibeeContext citibeeContext)
        {
            this._citibeeContext = citibeeContext;
        }

        public List<GereserveerdeItem> Bechikbaarheid(ZoekObject zoek) 
        {
            try
            {
                string query = String.Format(@"SELECT * FROM gereserveerde_item 
                            where reservering_item_id = {2}
                            and einddatum > '{0}'  and
                            startdatum not between '{1}' and einddatum
                            and einddatum not between '{1}' and startdatum", zoek.Begintijd, zoek.Eindtijd, zoek.ParkingId);
                return this._citibeeContext.VoerQueryUit<GereserveerdeItem>(query);
            }
            catch (Exception e)
            {
                throw new Exception("Geen ReserveringItem");
            }

        }
        public void ReserveerItem(GereserveerdeItem item)
        {
              if (item != null)
                {
                    this._citibeeContext.GereserveerdeItem.Add(item);
                    this._citibeeContext.SaveChanges();
                }
                else
                {
                    throw new Exception("ongeldige item mee gegeven");
                }
            

        }
    }
}
