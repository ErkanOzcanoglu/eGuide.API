﻿using AutoMapper;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entites.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers
{
    public class UserVehicleMapper : BaseMapper<UserVehicle, UserVehicleDto, UpdateDtoForUserVehicle, CreationDtoForUserVehicle> {}
}
