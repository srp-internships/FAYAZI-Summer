using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence;

namespace Warehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new WarehouseContext()))
            {
                var prod = new Product
                {
                    Name = "Test",
                    Quantity = 7,
                    Price = 10.5M
                };

                var prov = new Provider
                {
                    Name = "Russia"
                };
                unitOfWork.Providers.Add(prov);

                //var cust = unitOfWork.Customers.Get(1);

                NewProduct(unitOfWork, prod, prov);
                //SellProduct(unitOfWork, prod.Name, cust, 5);

                unitOfWork.Complete();
            }
        }
        public static void NewProduct(UnitOfWork unitOfWork, Product product, Provider provider)
        {
            var prod = unitOfWork.Products.GetProductByName(product.Name);

            var order = new Order
            {
                Product = product,
                Quantity = product.Quantity,
                Price = product.Quantity * product.Price,
                Provider = provider
            };

            unitOfWork.Orders.Add(order);

            if (prod == null)
            {
                unitOfWork.Products.Add(product);
                return ;
            }
            prod.Quantity += product.Quantity;
        }

        public static void SellProduct(UnitOfWork unitOfWork, string name, Customer customer, int quantity)
        {
            var prod = unitOfWork.Products.GetProductByName(name);
            var cust = unitOfWork.Customers.Get(customer.Id);

            if (prod == null || cust == null)
            {
                return;
            }
            unitOfWork.Products.Sell(prod, customer, quantity);
        }

        public static void Report(UnitOfWork unitOfWork)
        {
            var orders = unitOfWork.Orders.GetAll();
            var sell = orders.Where(o => o.Provider == null).Sum(o => o.Price);
            var buy = orders.Where(o => o.Customer == null).Sum(o => o.Price);

            Console.WriteLine($"Bought: {buy}");
            Console.WriteLine($"Sold: {sell}");
            Console.WriteLine($"Profit: {sell-buy}");
        }
    }
}
