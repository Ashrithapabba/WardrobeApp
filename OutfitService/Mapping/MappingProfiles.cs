using AutoMapper;
using OutfitService.Dto;
using OutfitService.Models;

namespace OutfitService.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Outfit, OutfitDTo>().ReverseMap();
        }
 
    }
}