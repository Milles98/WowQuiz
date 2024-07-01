using CommunityToolkit.Mvvm.ComponentModel;
using WowQuiz.Models;

namespace WowQuiz.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private User? _currentUser;

    public string UserName => CurrentUser?.Name ?? "Guest";

    partial void OnCurrentUserChanged(User? value)
    {
        OnPropertyChanged(nameof(UserName));
    }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }
}
