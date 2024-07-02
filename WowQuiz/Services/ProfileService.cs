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
            var userId = GetCurrentUserId(); //fixa
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
                user.Password = password;
                user.Role = role;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private int GetCurrentUserId()
        {
            //fixa
            return 1;
        }
    }
}
