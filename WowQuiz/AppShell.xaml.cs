namespace WowQuiz
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.Current.GoToAsync("//LoginView");
        }
    }
}
