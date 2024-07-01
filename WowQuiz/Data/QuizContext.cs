using Microsoft.EntityFrameworkCore;
using WowQuiz.Models;

namespace WowQuiz.Data;

public class QuizContext : DbContext
{
    public DbSet<Question> Questions { get; set; }

    public QuizContext()
    {
        SQLitePCL.Batteries_V2.Init();
        
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "quiz.db3");
        
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                Id = 1,
                QuestionText = "What is the capital city of the Night Elves?",
                AnswersAsString = "Darnassus;Stormwind;Orgrimmar;Silvermoon",
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Id = 2,
                QuestionText = "Who is the last boss of Jade Serpent?",
                AnswersAsString = "Kil'jaeden;Sha;Arthas;Sylvanas",
                CorrectAnswerIndex = 1
            },
            new Question
            {
                Id = 3,
                QuestionText = "Due to Cata, what is the only way to get to Ebon Hold?",
                AnswersAsString = "Fly;Walk;Boat;Zeppelin",
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Id = 4,
                QuestionText = "How many bosses does Deadmines have?",
                AnswersAsString = "1;8;3;5",
                CorrectAnswerIndex = 3
            },
            new Question
            {
                Id = 5,
                QuestionText = "Who was the Lich King before Arthas?",
                AnswersAsString = "Ner'zhul;Illidan Stormrage;Bolvar Fordragon;Kil'jaeden",
                CorrectAnswerIndex = 0
            },
            new Question
            {
                Id = 6,
                QuestionText = "How many phases does the Lich King have when fighting him?",
                AnswersAsString = "1;5;4;2",
                CorrectAnswerIndex = 2
            },
            new Question
            {
                Id = 7,
                QuestionText = "Which zone in World of Warcraft is known for its giant mushrooms and spore creatures?",
                AnswersAsString = "Un'goro Crater;Zangarmash;Hellfire Peninsula;Nagrand",
                CorrectAnswerIndex = 1
            }
            // Add more questions as needed
        );
    }
}