using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Data.Dto.OutComing.Station {
    public class StationInformationDto {
        public Guid Id { get; set; }
        public Guid SocketId { get; set; }
        public Guid StationModelId { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string SocketType { get; set; }
        public string Current { get; set; }
        public string Voltage { get; set; }
        public string Icon { get; set; }
        public string ConnectorType { get; set; }
    }

}
