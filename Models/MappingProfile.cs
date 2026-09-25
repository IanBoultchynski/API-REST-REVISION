using AutoMapper;
using API_REST_REVISION.Models.DTO;

namespace API_REST_REVISION.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produit, ProduitDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProduit))
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.NomProduit))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IdTypeProduitNavigation != null ? src.IdTypeProduitNavigation.NomTypeProduit : null))
                .ForMember(dest => dest.Marque, opt => opt.MapFrom(src => src.IdMarqueNavigation != null ? src.IdMarqueNavigation.NomMarque : null));
        }
    }
}
