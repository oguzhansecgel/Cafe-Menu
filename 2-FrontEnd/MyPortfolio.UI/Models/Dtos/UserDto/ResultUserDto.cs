using Microsoft.AspNetCore.Identity;
using MyPortfolio.EntityLayer.Concrete;

namespace MyPortfolio.UI.Models.Dtos.UserDto
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
 

    }
}