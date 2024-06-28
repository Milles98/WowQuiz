using WowQuiz.Services;
using WowQuiz.ViewModels;

namespace WowQuiz.Views;

public partial class QuizPage : ContentPage
{
    public QuizPage()
    {
        InitializeComponent();
        BindingContext = new QuizViewModel(new QuestionService());
    }
}