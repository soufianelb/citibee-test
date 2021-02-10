using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using citibee_rest_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace citibee_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveringitemController : ControllerBase
    {

        private readonly ParkeergarageService _parkeergarageService;

        public ReserveringitemController(ParkeergarageService parkeergarageService)
        {
            this._parkeergarageService = parkeergarageService;
        }

        [HttpGet("Garage")]
        public ApiResponse Parkeergarages([FromQuery]int garage)
        {
            try
            {
                return new ApiResponse(this._parkeergarageService.AlleReserveringItemsPerGarage(garage));
            }
            catch (ApiException e)
            {
                throw new ApiException(e);
            }
        }
    }
}
