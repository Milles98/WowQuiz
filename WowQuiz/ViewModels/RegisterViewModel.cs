using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WowQuiz.Services;

namespace WowQuiz.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IRegisterService _registerService;

        [ObservableProperty]
        private string _name = string.Empty;

        private string _email = string.Empty;

        [ObservableProperty]
        private bool _isEmailValid = false;

        [ObservableProperty]
        private string _password = string.Empty;

        public RegisterViewModel(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        public string Email
        {
            get => _email;
            set
            {
                if (SetProperty(ref _email, value))
                {
                    IsEmailValid = IsValidEmail(value);
                    OnPropertyChanged(nameof(IsEmailValid));
                }
            }
        }

        [RelayCommand]
        private async Task RegisterAsync(INavigation navigation)
        {
            IsEmailValid = IsValidEmail(Email);
            if (!IsEmailValid)
            {
                await Shell.Current.DisplayAlert("Invalid Email", $"{Email} is invalid", "OK");
                return;
            }

            var userId = await _registerService.RegisterUserAsync(Name, Email, Password);

            if (userId != null)
            {
                await Shell.Current.DisplayAlert("Success", "Registration successful", "OK");
                await navigation.PopAsync();
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Registration failed", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }


    }
}