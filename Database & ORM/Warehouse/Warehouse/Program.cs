using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Xml.Linq;
using Warehouse.Core;
using Warehouse.Persistence;
using Warehouse.Persistence.Repositories;

namespace Warehouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new WarehouseContext()))
            {
                while(true)
                {
                    var userInput = Console.ReadKey(true);

                    switch (userInput.Key)
                    {
                        case ConsoleKey.Spacebar:
                            DisplayAll(unitOfWork);
                            break;
                        case ConsoleKey.N:
                            Console.Write("Input Product Id: ");
                            int prodId = int.Parse(Console.ReadLine());
                            var product = unitOfWork.Products.Get(prodId);

                            Console.Write("Input Provider Id: ");
                            int provId = int.Parse(Console.ReadLine());
                            var provider = unitOfWork.Providers.Get(provId);

                            NewProduct(unitOfWork, product, provider);
                            break;
                    }

                    unitOfWork.Complete();
                }
            }
            Console.ReadKey();
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
                return;
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
            Console.WriteLine($"Profit: {sell - buy}");
        }

        public static void DisplayAll(UnitOfWork unitOfWork)
        {
            Display(unitOfWork.Orders.GetAll());
            Display(unitOfWork.Customers.GetAll());
            Display(unitOfWork.Products.GetAll());
            Display(unitOfWork.Providers.GetAll());
        }

        public static void Display(IEnumerable e)
        {
            var className = e.GetType().GetGenericArguments()[0].Name;
            Console.WriteLine($"_____{className}_____");
            foreach (var order in e)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();
        }

       
    }
}
