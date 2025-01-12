using Microsoft.EntityFrameworkCore;
using QuizCore.Dane;
using QuizCore.Interfejsy;
using QuizCore.Modele;

namespace QuizCore.Serwisy
{
    public class QuizSerwis : IQuiz
    {
        public List<Quiz> PobierzWszystkieQuizy()
        {
            using var db = new QuizDbContext();
            return db.Quizy.Include(q => q.Pytania).ToList();
        }

        public Quiz PobierzQuizPoId(int id)
        {
            using var db = new QuizDbContext();
            return db.Quizy
                .Include(q => q.Pytania)
                .ThenInclude(p => p.Odpowiedzi)
                .FirstOrDefault(q => q.Id == id);
        }

        public void DodajQuiz(Quiz quiz)
        {
            using var db = new QuizDbContext();
            db.Quizy.Add(quiz);
            db.SaveChanges();
        }

        public void UsunQuiz(int id)
        {
            using var db = new QuizDbContext();
            var quiz = db.Quizy.Find(id);
            if (quiz != null)
            {
                db.Quizy.Remove(quiz);
                db.SaveChanges();
            }
        }
    }
}