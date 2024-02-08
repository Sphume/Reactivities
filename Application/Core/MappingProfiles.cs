using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() //add profiles where we want to go from, and where we want to go to
        {
            CreateMap<Activity, Activity>();
        }
    }
}