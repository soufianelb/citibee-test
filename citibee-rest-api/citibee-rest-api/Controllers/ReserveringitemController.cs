using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using citibee_rest_api.Models;
using citibee_rest_api.Services;
using citibee_rest_api.Zoek;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace citibee_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveringitemController : ControllerBase
    {

        private readonly ParkeergarageService _parkeergarageService;
        private readonly GereserveerditemService _gereserveerditemService;
        public ReserveringitemController(ParkeergarageService parkeergarageService, GereserveerditemService gereserveerditemService)
        {
            this._parkeergarageService = parkeergarageService;
            this._gereserveerditemService = gereserveerditemService;
        }

        [HttpGet("Garage")]
        public ApiResponse Parkeergarages([FromQuery]int garage)
        {
            try
            {
                return new ApiResponse(this._parkeergarageService.AlleReserveringItemsPerGarage(garage));
            }
            catch (Exception e)
            {
                throw new ApiException(e);
            }
        }

        [HttpPost("CheckBeschikbaar")]
        public ApiResponse CheckBeschikbaar([FromBody] ZoekObject zoekObject)
        {
            try
            {
                var resultaat = this._gereserveerditemService.Bechikbaarheid(zoekObject);
                if(resultaat.Count != 0)
                {
                    throw new Exception("Parking niet beschikbaar");
                }
                else
                {
                    return new ApiResponse("Parking beschikbaar");
                }
            }
            catch (Exception e)
            {
                throw new ApiException(e);
            }
        }

        [HttpPost("Reserveren")]
        public ApiResponse Reserveren([FromBody] GereserveerdeItem item)
        {
            try
            {
                  this._gereserveerditemService.ReserveerItem(item);
                return new ApiResponse();
               
            }
            catch (Exception e)
            {
                throw new ApiException(e);
            }
        }
    }
}
