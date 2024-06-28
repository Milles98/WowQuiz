using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Models;
using WowQuiz.Services;

namespace WowQuiz.ViewModels
{
    public partial class QuizViewModel : ObservableObject
    {
        [ObservableProperty]
        private Question? _currentQuestion;

        [ObservableProperty]
        private string _feedbackMessage = string.Empty;

        private readonly IQuestionService _questionService;

        private int _currentQuestionIndex = -1;

        private int _correctAnswersCount = 0;

        public string QuestionTracker => $"Question {_currentQuestionIndex + 1}/{Questions.Count}";

        public ObservableCollection<Question> Questions { get; } = new ObservableCollection<Question>();

        public QuizViewModel(IQuestionService questionService)
        {
            _questionService = questionService;
            LoadQuestionsAsync();
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
        public async Task CheckAnswer(string selectedAnswer)
        {
            bool isCorrect = selectedAnswer == CurrentQuestion.Answers[CurrentQuestion.CorrectAnswerIndex];

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
                    .ContinueWith(t =>
                    {
                        Shell.Current.GoToAsync("//MainPage");
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }
    }
}
