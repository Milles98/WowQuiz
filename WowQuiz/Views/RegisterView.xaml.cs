using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.ViewModels;

namespace WowQuiz.Views;

public partial class RegisterView : ContentPage
{
    public RegisterView(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    
    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        if (BindingContext is RegisterViewModel viewModel)
        {
            await viewModel.RegisterCommand.ExecuteAsync(Navigation);
        }
    }
}