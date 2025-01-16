using QuizCore.Modele;

namespace QuizRazor.Models
{
    public class QuizViewModel
    {
        public Quiz Quiz { get; set; }
        public Dictionary<int, int> WybraneOdpowiedzi { get; set; } = new Dictionary<int, int>();
        public int? Wynik { get; set; }
        public bool CzyZakonczony { get; set; }
    }
}