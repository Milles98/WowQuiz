using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Models;

namespace WowQuiz.ViewModels
{
    public partial class QuizViewModel : ObservableObject
    {
        [ObservableProperty]
        private Question _currentQuestion;

        [ObservableProperty]
        private string _feedbackMessage;

        public ObservableCollection<Question> Questions { get; } = new ObservableCollection<Question>();

        public QuizViewModel()
        {
            //ladda frågorna här
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
            // Example logic to move to the next question
            // This could involve updating the CurrentQuestion property
            // and resetting any necessary state for the next question
        }
    }
}
