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

            CreateMap<Produit, ProduitDetailDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProduit))
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.NomProduit))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IdTypeProduitNavigation != null ? src.IdTypeProduitNavigation.NomTypeProduit : null))
                .ForMember(dest => dest.Marque, opt => opt.MapFrom(src => src.IdMarqueNavigation != null ? src.IdMarqueNavigation.NomMarque : null))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nomphoto, opt => opt.MapFrom(src => src.NomPhoto))
                .ForMember(dest => dest.Uriphoto, opt => opt.MapFrom(src => src.UriPhoto))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.StockReel))
                .ForMember(dest => dest.EnReappro, opt => opt.MapFrom(src => src.StockReel < src.StockMin));

            CreateMap<Marque, MarqueDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdMarque))
                .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.NomMarque))
                .ForMember(dest => dest.NbProduits, opt => opt.MapFrom(src => src.Produits != null ? src.Produits.Count() : 0));
        }
    }
}

