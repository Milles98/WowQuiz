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
                    Answers = ["Darnassus", "Stormwind", "Orgrimmar", "Silvermoon"],
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    QuestionText = "Who is the last boss of Jade Serpent?",
                    Answers = ["Kil'jaeden", "Sha", "Arthas", "Sylvanas"],
                    CorrectAnswerIndex = 1
                },
                new Question
                {
                    QuestionText = "Due to Cata, what is the only way to get to Ebon Hold?",
                    Answers = ["Fly", "Walk", "Boat", "Zeppelin"],
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    QuestionText = "How many bosses does Deadmines have?",
                    Answers = ["1", "8", "3", "5"],
                    CorrectAnswerIndex = 3
                },
                new Question
                {
                    QuestionText = "Who was the Lich King before Arthas?",
                    Answers = ["Ner'zhul", "Illidan Stormrage", "Bolvar Fordragon", "Kil'jaeden"],
                    CorrectAnswerIndex = 0
                },
                new Question
                {
                    QuestionText = "How many phases does the Lich King have when fighting him?",
                    Answers = ["1", "5", "4", "2"],
                    CorrectAnswerIndex = 2
                },
                new Question
                {
                    QuestionText = "Which zone in World of Warcraft is known for its giant mushrooms and spore creatures?",
                    Answers = ["Un'goro Crater", "Zangarmash", "Hellfire Peninsula", "Nagrand"],
                    CorrectAnswerIndex = 1
                },
                //kan lägga till fler frågor
            };
        }
    }
}
