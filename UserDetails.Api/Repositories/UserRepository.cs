using UserDetails.Api.Data;
using Microsoft.EntityFrameworkCore;
using UserDetails.Api.Models.Entities;
using UserDetails.Api.Models;
using AutoMapper;

namespace UserDetails.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Select(u => new User
            {
                Id = u.Id,
                UserFullName = u.UserFullName,
                Email = u.Email
                // Include other properties as needed
            }).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var result = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserFullName = u.UserFullName,
                    Email = u.Email
                })
                .FirstOrDefaultAsync();

            return result ?? new User();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<int> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteUserAsync(int userId)
        {
            var filteredData = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            _context.Users.Remove(filteredData);
            return await _context.SaveChangesAsync();
        }
    }

    public class UserDummyRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>
        {
            new User { Id = 1, UserFullName = "John Doe", Email = "john.doe@example.com" },
            new User { Id = 2, UserFullName = "Doe Me", Email = "doe.me@example.com" },
            new User { Id = 3, UserFullName = "Alice Smith", Email = "alice.smith@example.com" }
        };

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult<IEnumerable<User>>(_users);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = _users.Where(x => x.Id == id).FirstOrDefault();

            return await Task.FromResult(user);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);

            return await Task.FromResult(user);
        }

        public Task<int> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
