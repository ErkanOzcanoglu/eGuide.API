using eGuide.Data.Dto.InComing.CreationDto.Client;
using eGuide.Data.Dto.InComing.CreationDto.Message;
using eGuide.Data.Dto.InComing.UpdateDto.Client;
using eGuide.Data.Dto.OutComing.Client;
using eGuide.Data.Dto.OutComing.Message;
using eGuide.Data.Entities.Client;
using eGuide.Data.Entities.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Common.Mappers
{
   public class MessageMapper : BaseMapper<Messages, MessageDto, Messages, CreationDtoForMessage> { }

}
