namespace QuizCore.Modele
{
    public class Odpowiedz
    {
        public int Id { get; set; }
        public string TrescOdpowiedzi { get; set; }
        public bool CzyPoprawna { get; set; }
        public int PytanieId { get; set; }
        public Pytanie Pytanie { get; set; }
    }
}