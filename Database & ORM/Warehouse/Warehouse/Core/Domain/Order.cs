using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Provider Provider { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id = {Id} | Customer = {Customer} | Product = {Product.Name} | Provider = {Provider} | Quantity = {Quantity} | Price = {Price}";
        }
    }
}
