using QuizCore.Modele;

namespace QuizCore.Interfejsy
{
    public interface IQuiz
    {
        List<Quiz> PobierzWszystkieQuizy();
        Quiz PobierzQuizPoId(int id);
        void DodajQuiz(Quiz quiz);
        void UsunQuiz(int id);
    }
}