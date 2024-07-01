using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WowQuiz.Models;

namespace WowQuiz.Services
{
    public interface IProfileService
    {
        Task<User> GetCurrentUserAsync();
        Task<bool> UpdateUserAsync(string name, string email, string password, string role);
    }
}
