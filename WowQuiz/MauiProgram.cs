using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using WowQuiz.Data;
using WowQuiz.Services;
using WowQuiz.ViewModels;
using WowQuiz.Views;

namespace WowQuiz
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Database
            builder.Services.AddDbContext<QuizContext>();
            
            // ViewModels
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<QuizViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddSingleton<MainViewModel>();
            
            // Services
            builder.Services.AddSingleton<IQuestionService, QuestionService>();
            builder.Services.AddTransient<ILoginService, LoginService>();
            builder.Services.AddTransient<IRegisterService, RegisterService>();
            
            // Views
            builder.Services.AddTransient<LoginView>();
            builder.Services.AddTransient<QuizPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<RegisterView>();
            builder.Services.AddTransient<ProfilePage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

/*Att vilja göra
 * Gör så att quiz frågor hämtas från ett API eller skapa själv API
 * Ändra startsidan att välja mellan olika wow quiz kategorier
 * låt användare spara sina resultat och se statistik
 * skapa något reward system för att få användare att spela mer
 * skapa en admin sida för att lägga till nya frågor
 
 
 * Klart
 * koppla till databas
 * skapa användare
 * gör inloggningssida så att användare registrerar och loggar in
*/
