namespace DAL.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Interfaces;
using Models;

public class OrderRepository : IOrderRepository
{
    private readonly TestDbContext context;

    public OrderRepository(TestDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        var orders = this.context.Orders?.ToList() ?? Enumerable.Empty<Order>();
        return orders;
    }

    public Order? GetOrderById(int id)
    {
        return this.context.Orders?.Single(o => o.OrderID == id);
    }

    public void CreateOrder(Order order)
    {
        this.context.Orders?.Add(order);
        this.context.SaveChanges();
    }

    public void UpdateOrder(Order order)
    {
        this.context.Orders?.Update(order);
        this.context.SaveChanges();
    }

    public void DeleteOrder(Order order)
    {
        this.context.Orders?.Remove(order);
        this.context.SaveChanges();
    }
}
