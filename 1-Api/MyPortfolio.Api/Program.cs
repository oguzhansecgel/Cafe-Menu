using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.BusinessLayer.Concrete;
using MyPortfolio.BusinessLayer.Validation.Category;
using MyPortfolio.BusinessLayer.Validation.Products;
using MyPortfolio.DataaccessLayer.Abstract;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.DataaccessLayer.EntityFramework;
using MyPortfolio.Dtos.CategoryDto;
using MyPortfolio.Dtos.ProductDto;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddTransient<IValidator<AddProductDto>, CreateProductValidator>();
builder.Services.AddTransient<IValidator<AddCategoryDto>, CreateCategoryValidator>();
//builder.Services.AddValidatorsFromAssemblyContaining(typeof(AddProductDto));
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CafeApiCors", opts =>
	{
		opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

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

app.UseAuthorization();
app.UseCors("CafeApiCors");
app.MapControllers();

app.Run();
