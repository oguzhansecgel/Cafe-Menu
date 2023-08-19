using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.Dtos.AppUserDto.Dto;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using MyPortfolio.EntityLayer.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

		public async Task<TokenDto> Login(LoginViewModel loginViewModel)
		{


			var user = await _userManager.FindByNameAsync(loginViewModel.Username);



			var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
			var expireDate = DateTime.Now.AddMinutes(expireMinute);

			//Token'i üret ve return et.
			var tokenString = GenerateJwtToken(user, expireDate);

			return new TokenDto
			{
				Token = tokenString,
				ExpireDate = expireDate
			};

		}

		private string GenerateJwtToken(Appuser appUser, DateTime expireDate)
		{
			var secretKey = _configuration["Jwt:SigninKey"];
			var issuer = _configuration["Jwt:Issuer"];
			var audiance = _configuration["Jwt:Audiance"];

			var claims = new Claim[]
			{
				new Claim(ClaimTypes.Name,appUser.UserName),
				new Claim(ClaimTypes.Email,appUser.Email),
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(secretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Audience = audiance,
				Issuer = issuer,
				Subject = new ClaimsIdentity(claims),
				Expires = expireDate, // Token süresi (örn: 20 dakika)
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

	}
}
