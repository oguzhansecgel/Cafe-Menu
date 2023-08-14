using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.RoleDto;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRoleController : ControllerBase
    {
        private readonly IAppRoleService _appRoleService;
        private readonly IMapper _mapper;

        public AppRoleController(IAppRoleService appRoleService, IMapper mapper)
        {
            _appRoleService = appRoleService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ListAppRole()
        {
            var values = _appRoleService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddRole(AddRoleDto addRoleDto)
        {
            var role = _mapper.Map<AppRole>(addRoleDto);
            role.NormalizedName = addRoleDto.Name.ToUpperInvariant();
            _appRoleService.TInsert(role);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var values = _appRoleService.TGetById(id);
            _appRoleService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRole(AddRoleDto addRoleDto)
        {
            var role = _mapper.Map<AppRole>(addRoleDto);     
            _appRoleService.TUpdate(role);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var values = _appRoleService.TGetById(id);
            return Ok(values);
        }
    }
}
