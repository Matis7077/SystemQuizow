using QuizCore.Dane;
using QuizCore.Interfejsy;
using QuizCore.Modele;

namespace QuizCore.Serwisy
{
    public class OdpowiedzSerwis : IOdpowiedz
    {
        public List<Odpowiedz> PobierzOdpowiedziDlaPytania(int pytanieId)
        {
            using var db = new QuizDbContext();
            return db.Odpowiedzi.Where(o => o.PytanieId == pytanieId).ToList();
        }

        public void DodajOdpowiedz(Odpowiedz odpowiedz)
        {
            using var db = new QuizDbContext();
            db.Odpowiedzi.Add(odpowiedz);
            db.SaveChanges();
        }
    }
}