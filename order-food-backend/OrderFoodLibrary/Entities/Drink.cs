using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodLibrary.Entities
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Alcoholic { get; set; }

        public Drink() { }

        public Drink(string name, bool alcoholic)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome da bebida é obrigatório.");

            Name = name;
            Alcoholic = alcoholic;
        }
    }
}
