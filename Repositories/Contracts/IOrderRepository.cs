using System.Dynamic;
using System.Globalization;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders{get;}
        Order? GetOneOrder(int id);
        void Complete(int id);
        void saveOrder(Order order);
        int NumberOfInProcess{get;}
    }
}