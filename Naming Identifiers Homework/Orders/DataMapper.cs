using System.Collections.Generic;
using System.Linq;
using o;
using System.IO;

namespace Orders
{
    public class dataMapper
    {
        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        public dataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public dataMapper()
            : this("../../Data/categories.txt", "../../Data/products.txt", "../../Data/orders.txt")
        {
        }

        public IEnumerable<Category> getAllCategories()
        {
            var cat = readFileLines(this.categoriesFileName, true);
            return cat
                .Select(category => category.Split(','))
                .Select(category => new Category
                {
                    Id = int.Parse(category[0]),
                    Name = category[1],
                    Description = category[2]
                });
        }

        public IEnumerable<Product> getAllProducts()
        {
            var products = readFileLines(this.productsFileName, true);
            return products
                .Select(product => product.Split(','))
                .Select(product => new Product
                {
                    Id = int.Parse(product[0]),
                    Name = product[1],
                    CategoryID = int.Parse(product[2]),
                    UnitPrice = decimal.Parse(product[3]),
                    UnitsInStock = int.Parse(product[4]),
                });
        }

        public IEnumerable<Order> getAllOrders()
        {
            var orders = readFileLines(this.ordersFileName, true);
            return orders
                .Select(order => order.Split(','))
                .Select(order => new Order
                {
                    Id = int.Parse(order[0]),
                    ProductId = int.Parse(order[1]),
                    Quantity = int.Parse(order[2]),
                    Discount = decimal.Parse(order[3]),
                });
        }

        private List<string> readFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
