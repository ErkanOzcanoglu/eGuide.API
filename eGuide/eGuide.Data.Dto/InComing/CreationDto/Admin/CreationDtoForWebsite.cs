using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Admin 
{
    public class CreationDtoForWebsite: BaseDto
    {
        public int Navbar { get; set; }
        public int Footer { get; set; }
    }
}
