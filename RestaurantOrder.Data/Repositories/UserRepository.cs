﻿using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Data.Models;

namespace RestaurantOrder.Data.Repositories
{
    public interface IUserRepository
    {
        User Add(User user);
        Task<int> Commit();
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(long id);
        Task<bool> HasAnyAdmin();
    }

    public class UserRepository : IUserRepository
    {
        private readonly RestaurantContext _dbContext;

        public UserRepository(RestaurantContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(long id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            return user;
        }

        public async Task<int> Commit()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> HasAnyAdmin()
        {
            return await _dbContext.Users.AnyAsync(user => user.UserType == UserType.RestaurantOwner);
        }
    }
}
