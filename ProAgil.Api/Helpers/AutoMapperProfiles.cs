using System.Linq;
using AutoMapper;
using ProAgil.Api.Dtos;
using ProAgil.Domain;

namespace ProAgil.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(dest => dest.Palestrantes, opt => {
            // muitos para muitos
                    opt.MapFrom( src => src.PalestranteEventos.Select(x => x.Palestrante).ToList());
                })
                .ReverseMap();   
            
            CreateMap<Palestrante, PalestranteDto>()
                .ForMember(dest => dest.Eventos, opt => {
                    opt.MapFrom(src => src.PalestranteEventos.Select(x => x.Evento).ToList());
                })
                .ReverseMap();
    
            
            //parte do Dominio , e View 
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            
        }
    }
}