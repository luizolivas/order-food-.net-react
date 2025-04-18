using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderFoodLibrary.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


        public OrderItem() { }

        public OrderItem(int id, Dish dish, decimal unitPrice, int quantity)
        {
            if (dish == null)
            {
                throw new ArgumentNullException(nameof(dish), "Order Item recebido igual a null");
            }
            if (decimal.IsNegative(unitPrice))
                throw new ArgumentException("Valor do Prato não pode ser negativo");

            if (int.IsNegative(quantity) || quantity <= 0)
                throw new ArgumentException("Quantidade não pode ser negativo ou menor que zero. Quantidade: " + quantity );

            Dish = dish;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
