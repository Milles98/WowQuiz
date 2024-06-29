using WowQuiz.Views;

namespace WowQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage());
        }
    }

}
