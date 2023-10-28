using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Entities.Station
{
    public class StationInformationModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Socket { get; set; }
    }
}
