using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="eGuide.Service.AdminAPI.Controllers.GenericController&lt;eGuide.Data.Entities.Admin.AdminProfile, eGuide.Data.Dto.OutComing.Admin.AdminProfileDto, eGuide.Data.Dto.InComing.UpdateDto.Admin.UpdateDtoForAdmin, eGuide.Data.Dto.InComing.CreationDto.Admin.CreationDtoForAdminProfile&gt;" />
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : GenericController<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> {

        /// <summary>
        /// The business
        /// </summary>
        private readonly IBusiness<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> _business;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="business">The business.</param>
        public AdminController(IBusiness<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> business) : base(business) {
            _business = business;
        }
    }
}
