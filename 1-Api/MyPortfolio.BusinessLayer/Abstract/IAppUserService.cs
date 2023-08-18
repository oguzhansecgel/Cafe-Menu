using MyPortfolio.Dtos.AppUserDto;
using MyPortfolio.Dtos.AppUserDto.Dto;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Abstract
{
	public interface IAppUserService : IGenericService<Appuser>
	{
		Task<TokenDto> Login(LoginViewModel loginViewModel);

	}
}
