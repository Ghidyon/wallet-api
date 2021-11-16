using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletApi.Models.Dtos;
using WalletApi.Models.Entities;

namespace WalletApi.Models.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<UserDto, User>();
        }
    }
}
