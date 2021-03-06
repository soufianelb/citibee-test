﻿using citibee_rest_api.Dal;
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

        
        public List<ReserveringItem> AlleReserveringItemsPerGarage(int garage) 
        {
            try
            {
                return this._citibeeContext.ReserveringItem
                    .Join(this._citibeeContext.ReserveringItemType, item => item.ItemTypeId, itemType => itemType.Id, (item, itemType) => new ReserveringItem() {
                        Barcode = item.Barcode,
                        Id = item.Id,
                        ItemType = itemType,
                        ParkeergarageId=item.ParkeergarageId,
                        Parkingnr= item.Parkingnr,
                        ItemTypeId = item.ItemTypeId,
                        
                    })
                    .Where(y=>y.ParkeergarageId.Equals(garage)).ToList();
            }
            catch (Exception e)
            {
                throw new Exception("Geen ReserveringItem");
            }

        }

    }
}
