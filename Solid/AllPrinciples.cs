using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Solid.AllPrinciples;

namespace Solid
{
    internal class AllPrinciples
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
        public class Order
        {
            public string CustomerName { get; set; }
            public List<Product> Products { get; set; }
            public decimal TotalCost { get; set; }
        }

        public interface IPaymentProcessor
        {
            void ProcessPayment(decimal amount);
        }
        public class CreditCardPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine($"Processing credit card payment of ${amount}");
            }
        }
        public class PayPalPaymentProcessor : IPaymentProcessor
        {
            public void ProcessPayment(decimal amount)
            {
                Console.WriteLine($"Processing PayPal payment of ${amount}");
            }
        }
        public interface INotificationService
        {
            void SendOrderConfirmationEmail(Order order);
        }
        public class EmailNotificationService : INotificationService
        {
            public void SendOrderConfirmationEmail(Order order)
            {
                string message = $"Order confirmation for {order.CustomerName}:\n";
                message += $"Total Cost: ${order.TotalCost}\n";
                message += "Products:\n";
                foreach (Product product in order.Products)
                {
                    message += $"- {product.Name} (${product.Price})\n";
                }
                Console.WriteLine(message);
            }
        }
        public interface IProductManager
        {
            void AddProduct(string name, decimal price, int quantity);
            List<Product> GetProductsByIds(List<int> productIds);
        }
        public class ProductManager : IProductManager
        {
            private readonly List<Product> _products = new List<Product>();
            public void AddProduct(string name, decimal price, int quantity)
            {
                _products.Add(new Product { Name = name, Price = price, Quantity = quantity });
            }
            public List<Product> GetProductsByIds(List<int> productIds)
            {
                List<Product> orderedProducts = new List<Product>();
                foreach (int productId in productIds)
                {
                    Product product = _products.Find(p => p.Id == productId);
                    if (product != null && product.Quantity > 0)
                    {
                        orderedProducts.Add(product);
                    }
                }
                return orderedProducts;
            }
        }
        public interface IOrderManager
        {
            decimal ProcessOrder(List<Product> orderedProducts);
            Order MakeOrder(string customerName, List<Product> products, decimal cost);
        }
        public class OrderManager : IOrderManager
        {
            private readonly List<Order> _Orders = new List<Order>();
            public decimal ProcessOrder(List<Product> orderedProducts)
            {
                decimal totalCost = 0;
                foreach (Product product in orderedProducts)
                {
                    totalCost += product.Price;
                    product.Quantity--;
                }
                return totalCost;
            }
            public Order MakeOrder(string customerName, List<Product> products, decimal cost)
            {
                Order order = new Order
                {
                    CustomerName = customerName,
                    Products = products,
                    TotalCost = cost
                };
                _Orders.Add(order);
                return order;
            }
        }
        public class ECommerceSystem
        {
            private readonly IProductManager _productManager;
            private readonly IOrderManager _orderManager;
            private readonly IPaymentProcessor _paymentProcessor;
            private readonly INotificationService _notificationService;

            public ECommerceSystem(IProductManager productManager, IOrderManager orderManager,
                                   IPaymentProcessor paymentProcessor, INotificationService notificationService)
            {
                _productManager = productManager;
                _orderManager = orderManager;
                _paymentProcessor = paymentProcessor;
                _notificationService = notificationService;
            }

            public void AddProduct(string name, decimal price, int quantity)
            {
                _productManager.AddProduct(name, price, quantity);
            }

            public void PlaceOrder(string customerName, List<int> productIds, string paymentMethod)
            {
                List<Product> orderedProducts = _productManager.GetProductsByIds(productIds);
                if (orderedProducts.Count > 0)
                {
                    decimal totalCost = _orderManager.ProcessOrder(orderedProducts);
                    _paymentProcessor.ProcessPayment(totalCost);
                    Order order = _orderManager.MakeOrder(customerName, orderedProducts, totalCost);
                    _notificationService.SendOrderConfirmationEmail(order);
                }
            }
        }
    }
}
