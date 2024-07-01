using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Services;

namespace WowQuiz.ViewModels
{
    public partial class ProfileViewModel : ObservableObject
    {
        private readonly IProfileService _profileService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string role;

        public ProfileViewModel(IProfileService profileService)
        {
            _profileService = profileService;
            LoadUserProfile(); // Ensure user profile is loaded when ViewModel is initialized
        }

        private async void LoadUserProfile()
        {
            var user = await _profileService.GetCurrentUserAsync();
            if (user != null)
            {
                Name = user.Name;
                Email = user.Email;
                Password = user.Password; // Note: Consider security implications
                Role = user.Role;
            }
        }

        [RelayCommand]
        private async Task SaveChangesAsync()
        {
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
    }
}
