using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implemetions
{
    public class OrderService : IOrderService
    {

        private readonly ApplicationDbContext _appDbContext;

        public OrderService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Order> GetOrder()
        {
            var orderWithHighestTotal = await _appDbContext.Orders
                .OrderByDescending(o => o.Price * o.Quantity)
                .FirstOrDefaultAsync();

            return orderWithHighestTotal;
        }

        public async Task<List<Order>> GetOrders()
        {

            int quantity = 10;
            var ordersWithQuantityGreaterThan = await _appDbContext.Orders
               .Where(o => o.Quantity > quantity)
               .ToListAsync();

            return ordersWithQuantityGreaterThan;
        }
    }
}
