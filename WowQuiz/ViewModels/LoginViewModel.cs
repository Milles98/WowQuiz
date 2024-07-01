using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WowQuiz.Services;

namespace WowQuiz.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly ILoginService _loginService;
    private readonly IServiceProvider _serviceProvider;
    
    [ObservableProperty]
    private string _email = string.Empty;
    
    [ObservableProperty]
    private string _password = string.Empty;
    
    [ObservableProperty]
    private string _loginMessage = string.Empty;

    public LoginViewModel(ILoginService loginService, IServiceProvider serviceProvider)
    {
        _loginService = loginService;
        _serviceProvider = serviceProvider;
    }
    
    [RelayCommand]
    private async Task LoginAsync()
    {
        var user = await _loginService.LoginAsync(Email, Password);
        if (user is not null)
        {
            _loginMessage = "Login successful";
            var mainpage = _serviceProvider.GetRequiredService<MainPage>();
            await Shell.Current.GoToAsync("//MainPage", true);
        }
        else
        {
            LoginMessage = "Invalid email or password";
        }
    }
    
    [RelayCommand]
    private async Task RegisterAsync()
    {
        // await _navigation.PushAsync(new RegisterPage());
    }
}