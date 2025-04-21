using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodLibrary.DTOs
{
    public class DishDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Avaliable { get; set; }
        public int CategoryId { get; set; }
    }
}
