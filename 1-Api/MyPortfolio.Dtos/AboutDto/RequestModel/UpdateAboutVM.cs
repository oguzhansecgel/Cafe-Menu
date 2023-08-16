using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.AboutDto.RequestModel
{
    public class UpdateAboutVM
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
