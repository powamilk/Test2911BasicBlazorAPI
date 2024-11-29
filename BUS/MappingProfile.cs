using AutoMapper;
using BUS.ViewModel;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Work, WorkVM>().ReverseMap();
            CreateMap<WorkCreateVM, Work>().ReverseMap();
            CreateMap<WorkUpdateVM, Work>().ReverseMap();
        }
    }
}
