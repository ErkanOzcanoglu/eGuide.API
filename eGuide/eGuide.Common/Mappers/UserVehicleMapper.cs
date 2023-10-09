using AutoMapper;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Entites.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers
{
    public class UserVehicleMapper: Profile {
        public UserVehicleMapper()
        {
            CreateMap<CreationDtoForUserVehicle, UserVehicle>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();

            CreateMap<UpdateDtoForUserVehicle, UserVehicle>()
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now)).ReverseMap();
        }
    
    }
}
