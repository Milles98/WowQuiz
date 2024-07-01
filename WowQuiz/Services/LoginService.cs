using Microsoft.EntityFrameworkCore;
using WowQuiz.Data;
using WowQuiz.Models;

namespace WowQuiz.Services;

public class LoginService : ILoginService
{
    private readonly QuizContext _context;

    public LoginService(QuizContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}