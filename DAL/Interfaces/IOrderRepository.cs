namespace DAL.Interfaces;

using global::DAL.Models;

public interface IOrderRepository
{
    IEnumerable<Order> GetAllOrders();

    Order? GetOrderById(int id);

    void CreateOrder(Order order);

    void UpdateOrder(Order order);

    void DeleteOrder(Order order);
}
