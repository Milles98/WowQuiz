using System.Threading.Tasks;
using WowQuiz.Data;
using WowQuiz.Models;

namespace WowQuiz.Services
{
    public class ProfileService : IProfileService
    {
        private readonly QuizContext _context;

        public ProfileService(QuizContext context)
        {
            _context = context;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            // Assuming you have a way to get the current user's ID
            var userId = GetCurrentUserId();
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<bool> UpdateUserAsync(string name, string email, string password, string role)
        {
            var userId = GetCurrentUserId();
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;
                user.Password = password; // Consider hashing the password
                user.Role = role;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private int GetCurrentUserId()
        {
            // Implement logic to retrieve the current user's ID
            // This is just a placeholder implementation
            return 1;
        }
    }
}
