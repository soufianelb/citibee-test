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
    public class ParkeergarageController : ControllerBase
    {
        private readonly ParkeergarageService _parkeergarageService;

        public ParkeergarageController(ParkeergarageService parkeergarageService) 
        {
            this._parkeergarageService = parkeergarageService;
        }

        [HttpGet]
        public ApiResponse Parkeergarages()
        {
            try
            {   
               return new ApiResponse(this._parkeergarageService.AlleParkeerGarage());
            }
            catch (ApiException e)
            {
                throw new ApiException(e);
            }
        }

    }
}
