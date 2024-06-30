using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using WowQuiz.Models;
using WowQuiz.Services;

namespace WowQuiz.ViewModels;

public partial class QuizViewModel : ObservableObject
{
    [ObservableProperty]
    private Question? _currentQuestion;

    [ObservableProperty]
    private string _feedbackMessage = string.Empty;

    private readonly IQuestionService _questionService;

    private int _currentQuestionIndex = -1;

    private int _correctAnswersCount;

    public string QuestionTracker => $"Question {_currentQuestionIndex + 1}/{Questions.Count}";

    private ObservableCollection<Question> Questions { get; } = [];

    public QuizViewModel(IQuestionService questionService)
    {
        _questionService = questionService;
        _ = LoadQuestionsAsync();
    }

    private async Task LoadQuestionsAsync()
    {
        var questions = await _questionService.GetQuestionsAsync();
        foreach (var question in questions)
        {
            Questions.Add(question);
        }
        MoveToNextQuestion();
    }

    [RelayCommand]
    private async Task CheckAnswer(string selectedAnswer)
    {
        var isCorrect = selectedAnswer == CurrentQuestion?.Answers[CurrentQuestion.CorrectAnswerIndex];

        if (isCorrect)
        {
            _correctAnswersCount++;
        }

        FeedbackMessage = isCorrect ? "Correct!" : "False!";

        await Shell.Current.DisplayAlert("Result", FeedbackMessage, "Go to the next question");
        // await Shell.Current.Navigation.PushModalAsync(
        //     new CustomAlertPage("Result", FeedbackMessage, "Go to the next question", isCorrect ? Colors.Green : Colors.Red));

        MoveToNextQuestion();
    }


    private void MoveToNextQuestion()
    {
        FeedbackMessage = string.Empty;
        if (_currentQuestionIndex + 1 < Questions.Count)
        {
            _currentQuestionIndex++;
            CurrentQuestion = Questions[_currentQuestionIndex];
            OnPropertyChanged(nameof(QuestionTracker));
        }
        else
        {
            DisplayQuizCompletedOptions();
            // Shell.Current.DisplayAlert("Quiz Completed", $"You got {_correctAnswersCount} out of {Questions.Count} questions correct! ", "OK")
            //     .ContinueWith(_ =>
            //     {
            //         Shell.Current.GoToAsync("//MainPage");
            //     }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

    private async void DisplayCompletionInfo()
    {
        await Shell.Current.DisplayAlert(
            "Quiz Completed",
            $"You got {_correctAnswersCount} out of {Questions.Count} questions correct!",
            "OK"
        );

        DisplayQuizCompletedOptions();
    }

    private async void DisplayQuizCompletedOptions()
    {
        var action = await Shell.Current.DisplayActionSheet(
            "Quiz Completed",
            "Cancel",
            null,
            "Go to the main page",
            "Try Again"
            );
        
        if(action == "Go to the main page")
        {
            Shell.Current.GoToAsync("//MainPage");
        }
        else if(action == "Try Again")
        {
            RestartQuiz();
        }
    }

    private void RestartQuiz()
    {
        _currentQuestionIndex = -1;
        _correctAnswersCount = 0;
        MoveToNextQuestion();
    }
}