namespace QuizCore.Modele
{
    public class Pytanie
    {
        public int Id { get; set; }
        public string TrescPytania { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public List<Odpowiedz> Odpowiedzi { get; set; } = new List<Odpowiedz>();
    }
}