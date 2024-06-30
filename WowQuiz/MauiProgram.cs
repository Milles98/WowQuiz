﻿using Microsoft.Extensions.Logging;
using WowQuiz.Services;

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

            builder.Services.AddSingleton<IQuestionService, QuestionService>();

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
 * koppla till databas och skapa användare som kan spara sina resultat
 * skapa något reward system för att få användare att spela mer
*/
