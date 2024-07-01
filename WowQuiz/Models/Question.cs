using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WowQuiz.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = null!;

        [NotMapped]
        public List<string> Answers
        {
            get => AnswersAsString.Split(';').ToList();
            set => AnswersAsString = string.Join(';', value);
        }

        public string AnswersAsString { get; set; } = null!;
        public int CorrectAnswerIndex { get; init; }
    }
}