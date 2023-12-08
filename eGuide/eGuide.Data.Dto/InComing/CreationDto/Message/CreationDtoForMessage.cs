using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.InComing.CreationDto.Message
{
    public class CreationDtoForMessage:BaseDto
    {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Content { get; set; }
    }
}
