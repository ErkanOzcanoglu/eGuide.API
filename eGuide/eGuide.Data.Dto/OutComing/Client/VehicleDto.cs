using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Client 
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Data.Entities.BaseModel" />
    public class VehicleDto : BaseDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
    }
}
