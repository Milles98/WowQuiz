using WowQuiz.Models;

namespace WowQuiz.Services;

public interface ILoginService
{
    Task<User?> LoginAsync(string email, string password);
}