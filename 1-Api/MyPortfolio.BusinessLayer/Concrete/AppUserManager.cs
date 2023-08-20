using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.BusinessLayer.Concrete
{
	public class AppUserManager : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;
		private readonly IConfiguration _configuration;
		private readonly Context _context;
		private readonly UserManager<Appuser> _userManager;
		public AppUserManager(IAppUserDal appUserDal, Context context, IConfiguration configuration, UserManager<Appuser> userManager)
		{
			_appUserDal = appUserDal;
			_context = context;
			_configuration = configuration;
			_userManager = userManager;
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
