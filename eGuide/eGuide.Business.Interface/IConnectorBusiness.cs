using eGuide.Data.Entities.Station;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IConnectorBusiness : IBusiness<Connector> {
        Task<List<Connector>> GetCon();
    }
}
