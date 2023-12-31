﻿using eGuide.Data.Context.Context;
using eGuide.Data.Entities.Admin;
using eGuide.Infrastructure.Concrete;
using eGuide.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eGuide.Infrastructure.Conctrete {
    public class WebsiteRepository : GenericRepository<Website>, IWebsiteRepository {

        /// <summary>
        /// The context
        /// </summary>
        private readonly eGuideContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebsiteRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public WebsiteRepository(eGuideContext context) : base(context) {
            _context = context;
        }

        public async Task<Website> UpdateFooter(Website website) {
            var res = await _context.Website.Where(x => x.Status == 1).FirstOrDefaultAsync();
            if( res == null) {
                return null;
            }
            res.Footer = website.Footer;
            await _context.SaveChangesAsync();
            return res;
        }

        public async Task<Website> UpdateNavbar(Website website) {
            var res = await _context.Website.Where(x => x.Status == 1).FirstOrDefaultAsync();
            if( res == null) {
                return null;
            }
            res.Navbar = website.Navbar;
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
