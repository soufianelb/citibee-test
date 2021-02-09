using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoWrapper.Wrappers;
using citibee_rest_api.Dto;
using citibee_rest_api.Models;
using citibee_rest_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace citibee_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikerController : ControllerBase
    {
        private readonly GebruikerService _gebruikerService;
        private readonly IMapper _mapper;

        public GebruikerController(GebruikerService gebruikerService, IMapper mapper)
        {
            this._gebruikerService = gebruikerService;
            this._mapper = mapper;
        }
  
        [HttpPost("Registreren")]
        public  ApiResponse Registreren([FromBody]Gebruiker gebruiker)
        {
            try
            {
                this._gebruikerService.Registreer(gebruiker);
                return new ApiResponse();
            }
            catch (ApiException e)
            {
                throw new ApiException(e);
            }
        }
        [HttpPost("Aanmelden")]
        public ApiResponse Aanmelden([FromBody]Gebruiker gebruiker)
        {
            try
            {
              var resultaat=  this._gebruikerService.GebruikerByEmailWachtwoord(gebruiker);
                return new ApiResponse(this._mapper.Map<GebruikerDto>(resultaat));
            }
            catch (ApiException e)
            {
                throw new ApiException(e.Message, 500);
                 
            }
        }
    }
}
