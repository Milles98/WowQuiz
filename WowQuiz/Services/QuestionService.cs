using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Models;

namespace WowQuiz.Services
{
    public class QuestionService : IQuestionService
    {
        public async Task<List<Question>> GetQuestionsAsync()
        {
            return new List<Question>
            {
                new Question
                {
                    QuestionText = "What is the capital city of the Night Elves?",
                    Answers = new List<string> {"Darnassus", "Stormwind", "Orgrimmar", "Silvermoon"},
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    QuestionText = "Who was the Lich King before Arthas?",
                    Answers = new List<string> {"Ner'zhul", "Illidan Stormrage", "Bolvar Fordragon", "Kil'jaeden"},
                    CorrectAnswerIndex = 0
                }
            };
        }
    }
}
