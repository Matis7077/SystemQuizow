using QuizCore.Modele;

namespace QuizCore.Interfejsy
{
    public interface IPytanie
    {
        List<Pytanie> PobierzPytaniaDlaQuizu(int quizId);
        void DodajPytanie(Pytanie pytanie);
    }
}