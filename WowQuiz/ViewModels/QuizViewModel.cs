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
        private Question _currentQuestion;

        [ObservableProperty]
        private string _feedbackMessage;
        private readonly IQuestionService _questionService;
        private int _currentQuestionIndex = -1;

        public ObservableCollection<Question> Questions { get; } = new ObservableCollection<Question>();

        public QuizViewModel(IQuestionService questionService)
        {
            _questionService = questionService;
            LoadQuestionsAsync();
        }

        private async void LoadQuestionsAsync()
        {
            var questions = await _questionService.GetQuestionsAsync();
            foreach (var question in questions)
            {
                Questions.Add(question);
            }
            MoveToNextQuestion();
        }

        [RelayCommand]
        public async void CheckAnswer(int selectIndex)
        {
            bool isCorrect = selectIndex == CurrentQuestion.CorrectAnswerIndex;

            FeedbackMessage = isCorrect ? "Correct!" : "False!";

            await Shell.Current.DisplayAlert("Result", FeedbackMessage, "Go to the next question");

            MoveToNextQuestion();
        }

        private void MoveToNextQuestion()
        {
            if (_currentQuestionIndex + 1 < Questions.Count)
            {
                _currentQuestionIndex++;
                CurrentQuestion = Questions[_currentQuestionIndex];
            }
            else
            {
                Shell.Current.DisplayAlert("Quiz Completed", "You have completed the Quiz!", "OK");
            }
        }
    }
}
