﻿using eGuide.Data.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Business.Interface {
    public interface IWebsiteBusiness : IBusiness<Website> {
        Task<Website> UpdateNavbar(Website website);
        Task<Website> UpdateFooter(Website website);
    }
}
