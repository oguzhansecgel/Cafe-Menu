using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.AppUserDto.Dto
{
    public class TokenDto
    {
		public string Token { get; set; }
		public DateTime ExpireDate { get; set; }
	}
}
