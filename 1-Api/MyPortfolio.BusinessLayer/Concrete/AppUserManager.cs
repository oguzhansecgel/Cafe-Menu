using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.Dtos.AppUserDto;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;


        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<Appuser> TGetAll()
		{
			return _appUserDal.GetAll();
		}

		public Appuser TGetById(int id)
		{
			return _appUserDal.GetByID(id);
		}
		public void TDelete(Appuser t)
		{
			_appUserDal.Delete(t);
		}

		public void TInsert(Appuser t)
		{
			_appUserDal.Insert(t);
		}

		public void TUpdate(Appuser t)
        {
            _appUserDal.Update(t);
        }

       
    }
}
