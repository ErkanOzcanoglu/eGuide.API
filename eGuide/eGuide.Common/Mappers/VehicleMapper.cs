﻿using AutoMapper;
using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Entities.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers
{
    public class VehicleMapper : BaseMapper<Vehicle, VehicleDto, UpdateDtoForVehicle, CreationDtoForVehicle>{}
}
