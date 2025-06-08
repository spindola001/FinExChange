using FinExChange.Domain.Entities;
using FinExChange.Domain.Interfaces;
using FinExChange.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinExChange.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly FinExChangeDBContext _context;

        public UserRepository(FinExChangeDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> CreateUserAsync(User user)
            => await CreateUserAsync(new User
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            });

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User?>> GetAllUsersAsync() 
            => await _context.Users.ToListAsync();

        public async Task<User?> GetUserByIdAsync(Guid userId)
            =>  await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

        public async Task<string> GetUserPasswordHashAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            var userPasswordHash = await _context.Users
                .Where(u => u.Email == email)
                .Select(u => u.PasswordHash)
                .FirstOrDefaultAsync();

            return await Task.FromResult(userPasswordHash) ?? await Task.FromResult("");
        }

        public Task<string> GetUserPhoneNumberAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserPasswordAsync(string email, string newPasswordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserPhoneNumberAsync(Guid userId, string newPhoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
