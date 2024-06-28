using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Models;

namespace WowQuiz.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> GetQuestionsAsync();
    }
}
