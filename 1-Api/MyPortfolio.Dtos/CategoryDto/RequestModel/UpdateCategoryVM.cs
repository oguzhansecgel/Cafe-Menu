using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.Dtos.CategoryDto.RequestModel
{
    public class UpdateCategoryVM
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}
