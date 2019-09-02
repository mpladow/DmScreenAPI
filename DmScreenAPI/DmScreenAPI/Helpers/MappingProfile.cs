using AutoMapper;
using DmScreenAPI.Context.Entities;
using DmScreenAPI.Dtos;
using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Resource, ResourceDto>();
            CreateMap<ResourceDto, Resource>();
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
