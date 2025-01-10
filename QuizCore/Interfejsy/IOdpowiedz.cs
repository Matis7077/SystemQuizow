using QuizCore.Modele;

namespace QuizCore.Interfejsy
{
    public interface IOdpowiedz
    {
        List<Odpowiedz> PobierzOdpowiedziDlaPytania(int pytanieId);
        void DodajOdpowiedz(Odpowiedz odpowiedz);
    }
}