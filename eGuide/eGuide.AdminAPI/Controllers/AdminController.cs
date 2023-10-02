using eGuide.Business.Interface;
using eGuide.Data.Dto.InComing.CreationDto.Admin;
using eGuide.Data.Dto.InComing.UpdateDto.Admin;
using eGuide.Data.Dto.OutComing.Admin;
using eGuide.Data.Entities.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eGuide.Service.AdminAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : GenericController<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> {
        private readonly IBusiness<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> _business;

        public AdminController(IBusiness<AdminProfile, AdminProfileDto, UpdateDtoForAdmin, CreationDtoForAdminProfile> business) : base(business) {
            _business = business;
        }
    }
}
