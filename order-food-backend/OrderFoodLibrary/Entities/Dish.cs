using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodLibrary.Entities {
    public class Dish {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Avaliable { get; set; }
        public Category Category { get; set; }

        private Dish() { }

        public Dish(string name, string description, decimal price, bool avaliable, Category category) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do prato é obrigatório.");

            if (price <= 0)
                throw new ArgumentException("O preço deve ser maior que zero.");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Avaliable = avaliable;
            this.Category = category;
        }
    }
}
