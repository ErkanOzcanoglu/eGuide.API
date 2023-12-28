using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Message
{
   public class Messages:BaseModel
   {
        public Guid SenderId { get; set; }

        public Guid ReceiverId { get; set; }

        public string Content { get; set; }

     
    }
}
