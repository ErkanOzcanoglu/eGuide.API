using AutoMapper;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers {
    public class AdminProfileMapper : Profile {
        public AdminProfileMapper() {
            CreateMap<CreationDtoForAdminProfile, AdminProfile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
