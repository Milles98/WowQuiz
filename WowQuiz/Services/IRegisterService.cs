namespace WowQuiz.Services;

public interface IRegisterService
{
    Task<int?> RegisterUserAsync(string name, string email, string password);
}