using AutoMapper;
using ClosetService.Models;
using ClosetService.DTOs; // Assuming DTOs are in this folder

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Map ClothingItem to ClothingItemDto and vice versa
        CreateMap<ClothingItem, ClothingItemDto>().ReverseMap();

        // Map Outfit to OutfitDto and vice vers
    }
}
