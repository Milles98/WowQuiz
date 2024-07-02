using WowQuiz.ViewModels;
using WowQuiz.Views;

namespace WowQuiz
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;
        public MainPage(IServiceProvider serviceProvider, MainViewModel viewModel)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            var quizPage = _serviceProvider.GetRequiredService<QuizPage>();
            await Navigation.PushAsync(quizPage);
        }

        private async void OnProfileButtonClicked(object sender, EventArgs e)
        {
            var profilePage = _serviceProvider.GetRequiredService<ProfilePage>();
            await Navigation.PushAsync(profilePage);
        }
    }
}
