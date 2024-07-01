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


        public RegisterViewModel(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [RelayCommand]
        private async Task RegisterAsync(INavigation navigation)
        {
            var userId = await _registerService.RegisterUserAsync(Name, Email, Password);

            if (userId != null)
            {
                await Shell.Current.DisplayAlert("Success", "Registration successful", "OK");
                await navigation.PopAsync(); // Go back to the login page
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Registration failed", "OK");
            }
        }

    }
}