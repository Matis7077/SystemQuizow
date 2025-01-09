namespace QuizCore.Modele
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public List<Pytanie> Pytania { get; set; } = new List<Pytanie>();
    }
}