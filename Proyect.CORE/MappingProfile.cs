using AutoMapper;
using Proyect.Core.DTO;
using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Tasks,TaskDTO>().ReverseMap();
            CreateMap<Clients, ClientDTO>().ReverseMap();

        }
    }
}
