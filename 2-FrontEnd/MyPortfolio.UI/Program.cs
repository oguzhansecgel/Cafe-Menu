using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using MyPortfolio.DataaccessLayer.Concrete;
using MyPortfolio.EntityLayer.Concrete;
using MyPortfolio.UI.Models.RequestModel.About;
using MyPortfolio.UI.Models.RequestModel.Category;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<Appuser,AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
    config.Filters.Add(new AllowAnonymousFilter());
});

//giriþ yapýlmadýðýnda yönlendirilecek sayfa
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    options.LoginPath = "/Login/Index/";
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
