using AutoMapper;
using citibee_rest_api.Dto;
using citibee_rest_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace citibee_rest_api.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Gebruiker, GebruikerDto>().ForMember(opt =>
           opt.Email,
            dest => dest.MapFrom(src => src.Email))
        .ForMember(opt =>
            opt.Gebruikersnaam,
            dest => dest.MapFrom(src => src.Gebruikersnaam)).ForMember(opt =>
           opt.GereserveerdeItem,
            dest => dest.MapFrom(src => src.GereserveerdeItem)).ForMember(opt =>
           opt.Id,
            dest => dest.MapFrom(src => src.Id)); ;

 
            CreateMap<GebruikerDto, Gebruiker>().ForMember(opt =>
           opt.Email,
            dest => dest.MapFrom(src => src.Email))
        .ForMember(opt =>
            opt.Gebruikersnaam,
            dest => dest.MapFrom(src => src.Gebruikersnaam)).ForMember(opt =>
           opt.GereserveerdeItem,
            dest => dest.MapFrom(src => src.GereserveerdeItem)).ForMember(opt =>
           opt.Id,
            dest => dest.MapFrom(src => src.Id)); ;


        }

    }
}
