using WowQuiz.Services;
using WowQuiz.ViewModels;

namespace WowQuiz.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage(QuizViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        // BindingContext = new QuizViewModel(new QuestionService());
    }
}