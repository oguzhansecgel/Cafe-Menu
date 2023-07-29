﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BusinessLayer.Abstract;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.TGetAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddAbout(About about)
		{
			_aboutService.TInsert(about);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var values = _aboutService.TGetById(id);
			_aboutService.TDelete(values);
			return Ok();
		}
		[HttpPut]
		public IActionResult UpdateAbout(About about)
		{
			_aboutService.TUpdate(about);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var values = _aboutService.TGetById(id);
			return Ok(values);
		}
	}
}
