using Microsoft.EntityFrameworkCore;
using System;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implemetions
{
    public class UserService : IUserService
    {

        private readonly ApplicationDbContext _appDbContext;

        public UserService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<User> GetUser()
        {
            var userWithMostOrders = await _appDbContext.Users
                .OrderByDescending(u => u.Orders.Count)
                .FirstOrDefaultAsync();

            return userWithMostOrders;
        }


        public async Task<List<User>> GetUsers()
        {
            var inactiveUsers = await _appDbContext.Users
                .Where(u => u.Status == UserStatus.Inactive)
                .ToListAsync();

            return inactiveUsers;
        }
    }
}
