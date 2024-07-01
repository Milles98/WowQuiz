using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using WowQuiz.Services;
using WowQuiz.Views;

namespace WowQuiz.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly ILoginService _loginService;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<LoginViewModel> _logger;
    
    [ObservableProperty]
    private string _email = string.Empty;
    
    [ObservableProperty]
    private string _password = string.Empty;
    
    [ObservableProperty]
    private string _loginMessage = string.Empty;

    public LoginViewModel(ILoginService loginService, IServiceProvider serviceProvider, ILogger<LoginViewModel> logger)
    {
        _loginService = loginService;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    
    [RelayCommand]
    private async Task LoginAsync()
    {
        var user = await _loginService.LoginAsync(Email, Password);
        if (user is not null)
        {
            LoginMessage = "Login successful";
            var mainPage = _serviceProvider.GetRequiredService<MainPage>();
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
        try
        {
            _logger.LogInformation("Starting RegisterAsync method");

            if (_serviceProvider == null)
            {
                _logger.LogError("_serviceProvider is null");
                return;
            }

            var registerView = _serviceProvider.GetRequiredService<RegisterView>();

            if (registerView == null)
            {
                _logger.LogError("registerView is null");
                return;
            }

            if (Shell.Current == null)
            {
                _logger.LogError("Shell.Current is null");
                return;
            }

            if (Shell.Current.Navigation == null)
            {
                _logger.LogError("Shell.Current.Navigation is null");
                return;
            }

            await Shell.Current.Navigation.PushAsync(registerView);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while trying to navigate to RegisterView");
        }
    }
}