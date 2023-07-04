using Warehouse.Core;
using Warehouse.Core.Repositories;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WarehouseContext _context;
        public UnitOfWork(WarehouseContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Providers = new ProviderRepository(_context);
            Customers = new CustomerRepository(_context);
            Orders = new OrderRepository(_context);
        }

        public IProductRepository Products { get; set; }
        public IProviderRepository Providers { get; set; }
        public IOrderRepository Orders { get; set; }
        public ICustomerRepository Customers { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
