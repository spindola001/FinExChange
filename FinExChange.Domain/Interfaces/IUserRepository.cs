using FinExChange.Domain.Entities;

namespace FinExChange.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(User user);
        Task<bool> UserExistsAsync(string email);
        Task<IEnumerable<User?>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<string> GetUserPasswordHashAsync(string email);
        Task UpdateUserPasswordAsync(string email, string newPasswordHash);
        Task DeleteUserAsync(Guid userId);
        Task<string> GetUserPhoneNumberAsync(Guid userId);
        Task UpdateUserPhoneNumberAsync(Guid userId, string newPhoneNumber);
    }
}
