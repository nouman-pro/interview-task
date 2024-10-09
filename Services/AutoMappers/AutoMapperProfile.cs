using AutoMapper;
using DataAccess;
using Services.Services.Register.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SYS_Logins, RegisterRequestModel>().ReverseMap();
            CreateMap<SYS_Users, RegisterRequestModel>().ReverseMap();

        }
    }
}
