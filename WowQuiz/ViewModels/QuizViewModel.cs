﻿using CommunityToolkit.Mvvm.ComponentModel;
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
            Shell.Current.DisplayAlert("Quiz Completed", $"You got {_correctAnswersCount} out of {Questions.Count} questions correct! ", "OK")
                .ContinueWith(_ =>
                {
                    Shell.Current.GoToAsync("//MainPage");
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}