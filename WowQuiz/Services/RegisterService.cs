using Microsoft.EntityFrameworkCore;
using WowQuiz.Data;
using WowQuiz.Models;

namespace WowQuiz.Services;

public class RegisterService : IRegisterService
{
    private readonly QuizContext _context;

    public RegisterService(QuizContext context)
    {
        _context = context;
    }

    public async Task<int?> RegisterUserAsync(string name, string email, string password)
    {
        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            return null; // User already exists
        }

        var user = new User
        {
            Name = name,
            Email = email,
            Password = password, // Consider hashing the password
            Role = "User"
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.Id; // Return the newly registered user's ID
    }

}