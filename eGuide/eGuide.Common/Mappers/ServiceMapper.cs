using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers
{
    public class ServiceMapper : BaseMapper<Services, ServiceDto, UpdateDtoForService, CreationDtoForService> { }  
}
