namespace BLL.Services;

using DAL.Interfaces;
using DAL.Models;
using System;
using global::BLL.Interfaces;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public Order? GetOrderById(int id)
    {
        return this.orderRepository.GetOrderById(id);
    }

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }

    public IEnumerable<Order> GetOrdersByUserId(int userId)
    {
        var orders = this.orderRepository.GetAllOrders().Where(o => o.UserID == userId).ToList() ?? Enumerable.Empty<Order>();
        return orders;
    }

    public void CreateOrder(Order order)
    {
        try
        {
            var orders = this.orderRepository.GetAllOrders().Where(o => o.UserID == order.UserID);
            DateTime lastDate = orders.Max(o => o.OrderDate).Date;
            if (!DateTime.Now.Date.Equals(lastDate))
            {
                this.orderRepository.CreateOrder(order);
            }
        }
        catch (InvalidOperationException)
        {
            this.orderRepository.CreateOrder(order);
        } 
    }

    public void UpdateOrder(Order order)
    {
        this.orderRepository.UpdateOrder(order);
    }

    public void DeleteOrder(Order order)
    {
        this.orderRepository.DeleteOrder(order);
    }
}
