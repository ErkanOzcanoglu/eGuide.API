﻿using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.UpdateDto.Client
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseDto" />
    public class UpdateDtoForVehicle : BaseDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
