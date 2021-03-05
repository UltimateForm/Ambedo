using Ambedo.Models;
using AutoMapper;
using MongoDB.Driver;
using Dtos = Ambedo.Contract.Dtos;

namespace Ambedo.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Thootle, Dtos.Thootle>().ReverseMap();
            CreateMap<ThootleCategories, Dtos.ThootleCategories>().ReverseMap();
            CreateMap<Dtos.UnidentifiedThootle, Thootle>();
            CreateMap<ReplaceOneResult, Dtos.ReplaceOneResult>();
            CreateMap<DeleteResult, Dtos.DeleteResult>();
        }
    }
}
