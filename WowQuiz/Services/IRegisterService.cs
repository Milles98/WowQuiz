namespace WowQuiz.Services;

public interface IRegisterService
{
    Task<bool> RegisterUserAsync(string name, string email, string password);
}