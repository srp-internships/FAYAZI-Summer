using System.Linq;
using System.Runtime.CompilerServices;

namespace Warehouse.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Sell(Product product, Customer customer, int quantity);

        Product GetProductByName(string name);
    }
}
