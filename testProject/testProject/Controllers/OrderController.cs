using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics;
using testProject.Models;

namespace testProject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        private readonly ILogger<OrderController> logger;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            this.logger = logger;
            this.orderService = orderService;
        }

        public IActionResult OrdersList(int userId)
        {
            try
            {
                var orders = this.orderService.GetOrdersByUserId(userId);
                this.logger.LogInformation("Getting orders succeded");
                return View(new KeyValuePair<int, IEnumerable<Order>>(userId, orders));
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("Getting orders failed");
                return this.Error();
            }
        }

        [HttpGet]
        public IActionResult CreateOrder(int userId)
        {
            Order order = new Order
            {
                UserID = userId
            };
            return this.View(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.orderService.CreateOrder(order);
                    this.logger.LogInformation("Registration succeded");
                    return this.RedirectToAction("OrdersList", "Order", new { userId = order.UserID });
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Registration failed");
                }
            }

            return this.View(order.UserID);
        }

        public IActionResult Order(int orderId)
        {
            try
            {
                var order = this.orderService.GetOrderById(orderId);
                return View(order);
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("Getting order failed");
                return this.Error();
            }
        }

        public IActionResult UpdateOrder(Order order)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.orderService.UpdateOrder(order);
                    this.logger.LogInformation("Order updating succeded");
                    return this.RedirectToAction("OrdersList", "Order", new { userId = order.UserID });
                }
                catch (InvalidOperationException)
                {
                    this.logger.LogError("Order updating failed");
                }
            }

            return this.RedirectToAction("Order", "Order", new { orderId = order.OrderID });
        }

        public IActionResult DeleteOrder(int orderId)
        {
            var order = this.orderService.GetOrderById(orderId);
            try
            {
                this.orderService.DeleteOrder(order);
                this.logger.LogInformation("Order deleting succeded");
                return this.RedirectToAction("OrdersList", "Order", new { userId = order.UserID });
            }
            catch (InvalidOperationException)
            {
                this.logger.LogError("Order deleting failed");
            }

            return this.RedirectToAction("Order", "Order", new { orderId = order.OrderID });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}