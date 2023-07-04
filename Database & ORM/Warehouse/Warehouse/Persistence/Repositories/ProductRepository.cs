using System.Linq;
using System.Runtime.InteropServices;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly WarehouseContext _context;

        

        public ProductRepository(WarehouseContext context) : base(context)
        {
           _context = context;
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name); 
        }

        public void Sell(Product product, Customer customer, int quantity)
        {
            product.Quantity -= quantity;
            var order = new Order
            {
                Customer = customer,
                Product = product,
                Quantity = quantity,
                Price = product.Quantity * quantity
            };
            _context.Orders.Add(order);
        }
    }
}
