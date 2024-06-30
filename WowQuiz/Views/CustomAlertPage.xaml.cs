using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowQuiz.Views;

public partial class CustomAlertPage : ContentPage
{
    public CustomAlertPage(string title, string message, string closeButtonText, Color backgroundColor)
    {
        Content = new Frame
        {
            BackgroundColor = backgroundColor,
            Padding = 20,
            CornerRadius = 20,
            HasShadow = true,
            BorderColor = Colors.Black,
            Content = new StackLayout
            {
                Children =
                {
                    new Label { Text = title, FontAttributes = FontAttributes.Bold, FontSize = 20 },
                    new Label { Text = message },
                    new Button
                    {
                        Text = closeButtonText,
                        Command = new Command(async () => await Navigation.PopModalAsync())
                    }
                }
            }
        };
    }
}