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
        public void CheckAnswer(int selectIndex)
        {
            if (selectIndex == CurrentQuestion.CorrectAnswerIndex)
            {
                FeedbackMessage = "Correct!";
            }
            else
            {
                FeedbackMessage = "False!";
            }
        }
    }
}
