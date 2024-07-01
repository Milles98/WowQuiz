using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using WowQuiz.Views;

namespace WowQuiz
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            MainPage = new NavigationPage(serviceProvider.GetRequiredService<LoginView>());
        }
    }
}