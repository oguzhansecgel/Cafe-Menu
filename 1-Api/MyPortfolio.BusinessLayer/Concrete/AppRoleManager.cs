using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.BusinessLayer.Concrete
{
    public class AppRoleManager : IAppRoleService
    {
        private readonly IAppRoleDal _appRoleDal;

        public AppRoleManager(IAppRoleDal appRoleDal)
        {
            _appRoleDal = appRoleDal;
        }
        public List<AppRole> TGetAll()
        {
            return _appRoleDal.GetAll();
        }

        public AppRole TGetById(int id)
        {
            return _appRoleDal.GetByID(id);
        }

        public void TDelete(AppRole t)
        {
            _appRoleDal.Delete(t);
        }

        public void TInsert(AppRole t)
        {
            _appRoleDal.Insert(t);
        }

        public void TUpdate(AppRole t)
        {
            _appRoleDal.Update(t);
        }
    }
}
