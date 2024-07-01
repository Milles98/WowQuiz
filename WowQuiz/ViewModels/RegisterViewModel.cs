using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using WowQuiz.Services;

namespace WowQuiz.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IRegisterService _registerService;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private string _registrationMessage = string.Empty;

        public RegisterViewModel(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [RelayCommand]
        private async Task RegisterAsync(INavigation navigation)
        {
            var success = await _registerService.RegisterUserAsync(Name, Email, Password);

            if (success)
            {
                RegistrationMessage = "Registration successful! Please log in.";
                await navigation.PopAsync(); // Go back to the login page
            }
            else
            {
                RegistrationMessage = "Email already exists. Please use a different email.";
            }
        }
    }
}