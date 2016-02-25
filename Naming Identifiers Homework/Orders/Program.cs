using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new dataMapper();
            var categories = dataMapper.getAllCategories();
            var products = dataMapper.getAllProducts();
            var orders = dataMapper.getAllOrders();

            var fiveMostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProducts));
            Console.WriteLine(new string('-', 10));
            
            var countOfProductsInCategories = products
                .GroupBy(product => product.CategoryID)
                .Select(group => new { Category = categories.First(cat => cat.Id == group.Key)
                                        .Name, Count = group.Count() })
                .ToList();
            foreach (var item in countOfProductsInCategories)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            var topProductsByOrderQuantity = orders
                .GroupBy(order => order.ProductId)
                .Select(group => new { Product = products.First(product => product.Id == group.Key)
                                    .Name, Quantities = group.Sum(count => count.Quantity) })
                .OrderByDescending(quantity => quantity.Quantities)
                .Take(5);
            foreach (var item in topProductsByOrderQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            var mostProfitableCategory = orders
                .GroupBy(order => order.ProductId)
                .Select(group => new { catId = products.First(product => product.Id == group.Key)
                                        .CategoryID, price = products.First(product => product.Id == group.Key)
                                        .UnitPrice, quantity = group.Sum(product => product.Quantity) })
                .GroupBy(category => category.catId)
                .Select(group => new { category_name = categories.First(category => category.Id == group.Key).Name, total_quantity = group.Sum(grp => grp.quantity * grp.price) })
                .OrderByDescending(group => group.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.category_name, mostProfitableCategory.total_quantity);
        }
    }
}
