using eGuide.Data.Dto.OutComing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.Logger {
    public class UserLogs : BaseDto {
        public DateTime CreatedTime { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Source { get; set; }
    }
}
