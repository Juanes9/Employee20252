using Employee.shared.DTOs;
using Employee.shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace Employee.Backend.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        Task<User> GetUserAsync(string email);
        Task<User> GetUserAsync(Guid userId);

        Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);


        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();
    }
}
