using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Repositories;

namespace Warehouse.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly WarehouseContext _context;

        public OrderRepository(WarehouseContext context) : base(context)
        {
            _context = context;
        }
        public override IEnumerable<Order> GetAll()
        {

            _context.Providers.Load();
            _context.Products.Load();
            _context.Customers.Load();

            return _context.Orders.ToList();
        }

    }
}
