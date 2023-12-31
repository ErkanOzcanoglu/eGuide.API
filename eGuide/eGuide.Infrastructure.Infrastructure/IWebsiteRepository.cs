﻿using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Interface {
    public interface IWebsiteRepository : IGenericRepository<Website> {
        Task<Website> UpdateNavbar(Website website);
        Task<Website> UpdateFooter(Website website);

    }
}
