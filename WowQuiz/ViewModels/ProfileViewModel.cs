using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WowQuiz.Services;

namespace WowQuiz.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IProfileService _profileService;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string name;

        private string email;

        [ObservableProperty]
        private bool isEmailValid = false;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string role;

        public ProfileViewModel(IProfileService profileService)
        {
            _profileService = profileService;
            LoadUserProfile();
        }

        public string Email
        {
            get => email;
            set
            {
                if (SetProperty(ref email, value))
                {
                    IsEmailValid = IsValidEmail(value);
                    OnPropertyChanged(nameof(IsEmailValid));
                }
            }
        }

        private async void LoadUserProfile()
        {
            var user = await _profileService.GetCurrentUserAsync();
            if (user != null)
            {
                Id = user.Id;
                Name = user.Name;
                Email = user.Email;
                Password = user.Password;
                Role = user.Role;
            }
        }

        [RelayCommand]
        private async Task SaveChangesAsync()
        {
            IsEmailValid = IsValidEmail(Email);
            if (!IsEmailValid)
            {
                await Shell.Current.DisplayAlert("Invalid Email", $"{Email} is invalid", "OK");
                return;
            }

            var success = await _profileService.UpdateUserAsync(Name, Email, Password, Role);
            if (success)
            {
                // Notify user of success, e.g., "Profile updated successfully."
            }
            else
            {
                // Notify user of failure, e.g., "Failed to update profile."
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

    }
}
