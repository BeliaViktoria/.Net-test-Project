namespace BLL.Interfaces;

using DAL.Models;

public interface IOrderService
{
    Order? GetOrderById(int id);

    IEnumerable<Order> GetOrdersByUserId(int userId);

    void CreateOrder(Order order);

    void UpdateOrder(Order order);

    void DeleteOrder(Order order);
}
