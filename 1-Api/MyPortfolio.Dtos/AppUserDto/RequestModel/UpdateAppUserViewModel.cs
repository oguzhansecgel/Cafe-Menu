using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.AppUserDto.RequestModel
{
    public class UpdateAppUserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
