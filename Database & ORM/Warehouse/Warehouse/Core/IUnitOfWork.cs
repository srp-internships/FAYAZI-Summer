using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Repositories;

namespace Warehouse.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; set; }
        ICustomerRepository Customers { get; set; }
        IOrderRepository Orders { get; set; }
        IProviderRepository Providers { get; set; }
        int Complete();
    }
}
