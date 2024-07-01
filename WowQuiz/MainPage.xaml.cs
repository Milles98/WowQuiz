using WowQuiz.Views;

namespace WowQuiz
{
    public partial class MainPage : ContentPage
    {
        private readonly IServiceProvider _serviceProvider;
        public MainPage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            var quizPage = _serviceProvider.GetRequiredService<QuizPage>();
            await Navigation.PushAsync(quizPage);
        }
    }

}
