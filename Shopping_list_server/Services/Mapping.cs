using AutoMapper;
using Entities.Entities;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
