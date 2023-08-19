using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.BusinessLayer.Concrete;
using MyPortfolio.BusinessLayer.Validation.About;
using MyPortfolio.BusinessLayer.Validation.AppUser;
using MyPortfolio.BusinessLayer.Validation.Category;
using MyPortfolio.BusinessLayer.Validation.Products;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.DataaccessLayer.EntityFramework;
using MyPortfolio.Dtos.AboutDto.RequestModel;
using MyPortfolio.Dtos.AppUserDto.RequestModel;
using MyPortfolio.Dtos.CategoryDto.RequestModel;
using MyPortfolio.Dtos.ProductDto;
using MyPortfolio.EntityLayer.Concrete;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddIdentity<Appuser, AppRole>().AddEntityFrameworkStores<Context>();


#region Validation
builder.Services.AddTransient<IValidator<AddProductDto>, CreateProductValidator>();


builder.Services.AddTransient<IValidator<AddCategoryVM>, CreateCategoryValidator>();
builder.Services.AddTransient<IValidator<UpdateCategoryVM>, UpdateCategoryValidator>();


builder.Services.AddTransient<IValidator<CreateAboutVM>, CreateAboutValidator>();
builder.Services.AddTransient<IValidator<UpdateAboutVM>, UpdateAboutValidator>();

builder.Services.AddTransient<IValidator<LoginViewModel>, LoginValidator>();
builder.Services.AddTransient<IValidator<RegisterViewModel>, RegisterValidator>();

#endregion

#region Dependency Injection 
builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();

builder.Services.AddScoped<IAppRoleDal, EfAppRoleDal>();
builder.Services.AddScoped<IAppRoleService, AppRoleManager>();

builder.Services.AddScoped<IProductImageDal, EfProductImageDal>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();
#endregion

#region JWT TOKEN
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] {}
					}
				});
});


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CafeApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

		   .AddJwtBearer(options =>
		   {
               
               options.TokenValidationParameters = new TokenValidationParameters
			   {

				   ValidateIssuer = true,
				   ValidateAudience = true,
				   ValidateLifetime = true,
				   ValidateIssuerSigningKey = true,
				   ValidIssuer = builder.Configuration["Jwt:Issuer"], // JWT üreten tarafýn adý
				   ValidAudience = builder.Configuration["Jwt:Audiance"], // JWT'nin kullanýlacaðý alan adý
				   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigninKey"])) // Gizli anahtar
			   };
		   });

#endregion 

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
