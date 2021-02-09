using citibee_rest_api.Dal;
using citibee_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Services
{
    public class ParkeergarageService
    {
        private readonly CitibeeContext _citibeeContext;

        public ParkeergarageService(CitibeeContext citibeeContext) 
        {
            this._citibeeContext = citibeeContext;
        }

        public List<Parkeergarage> AlleParkeerGarage()
        {
            try
            {
                return this._citibeeContext.Parkeergarage.Select(x => x).ToList();
            }
            catch (Exception e) 
            {
                throw new Exception("Geen parkeergarages"); 
            }
        }

    }
}
