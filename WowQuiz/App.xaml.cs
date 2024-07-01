using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;
using WowQuiz.Views;

namespace WowQuiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}