using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders {get;}
        Order? GetOneOrder(int id);
        void Complete(int id);
        void saveOrder(Order order);
        int NumberOfInProcess{get;}
    }
}