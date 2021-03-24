using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using taskapi.Dtos;

namespace taskapi.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ItemForInsertDto, Item>();
            CreateMap<StepForInsertDto, Step>();
        }
    }
}
