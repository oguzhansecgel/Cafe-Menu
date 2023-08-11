using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyPortfolio.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DataaccessLayer.Concrete
{
	public class Context : IdentityDbContext<Appuser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-3QG9GTV;initial catalog = CafeMenu; integrated security=true");
		}

		public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories{ get; set; }
		public DbSet<Product>Products{ get; set; }

	}
}
