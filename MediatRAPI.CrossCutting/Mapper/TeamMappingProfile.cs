using AutoMapper;
using DDDAPI.Application.DTO;
using DDDAPI.Domain.Team;

namespace DDDAPI.CrossCutting.Mapper
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            #region [ DTO TO DOMAIN ]
            CreateMap<TeamCreateDTO, TeamEntity>()
                              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamDeleteDTO, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamUpdateDTO, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamListDTO, TeamEntity>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));
            #endregion

            #region [ DOMAIN TO DTO ]

            CreateMap<TeamEntity, TeamCreateDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamEntity, TeamDeleteDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamEntity, TeamUpdateDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            CreateMap<TeamEntity, TeamListDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                              .ForMember(dest => dest.Modality, opt => opt.MapFrom(src => src.Modality))
                              .ForMember(dest => dest.QtdPlayers, opt => opt.MapFrom(src => src.QtdPlayers));

            #endregion
        }
    }
}
