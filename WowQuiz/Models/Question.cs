using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WowQuiz.Models
{
    public class Question
    {
        public string QuestionText { get; set; } = null!;
        public List<string> Answers { get; set; } = null!;
        public int CorrectAnswerIndex { get; init; }
    }
}
