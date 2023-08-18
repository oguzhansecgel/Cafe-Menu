using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.EntityLayer.Concrete
{
    public class Appuser : IdentityUser<int>
    {
       
        public string Name { get; set; }
        public string Surname { get; set; } 

        //public string UserName { get; set; }
        
        
    }
}
