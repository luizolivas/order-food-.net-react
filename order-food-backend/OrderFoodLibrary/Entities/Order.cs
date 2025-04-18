using OrderFoodLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFoodLibrary.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int NumeroMesa { get; set; }
        public StatusPedido StatusPedido { get; set; }
        public DateTime DataHora { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}
