using Microsoft.EntityFrameworkCore;
using QuizCore.Dane;
using QuizCore.Interfejsy;
using QuizCore.Modele;

namespace QuizCore.Serwisy
{
    public class PytanieSerwis : IPytanie
    {
        public List<Pytanie> PobierzPytaniaDlaQuizu(int quizId)
        {
            using var db = new QuizDbContext();
            return db.Pytania
                .Include(p => p.Odpowiedzi)
                .Where(p => p.QuizId == quizId)
                .ToList();
        }

        public void DodajPytanie(Pytanie pytanie)
        {
            using var db = new QuizDbContext();
            db.Pytania.Add(pytanie);
            db.SaveChanges();
        }
    }
}