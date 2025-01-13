using QuizCore.Modele;
using QuizCore.Serwisy;

namespace QuizConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var quizSerwis = new QuizSerwis();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM QUIZÓW - KONSOLA ===");
                Console.WriteLine("1. Dodaj nowy quiz");
                Console.WriteLine("2. Wyświetl wszystkie quizy");
                Console.WriteLine("3. Usuń quiz");
                Console.WriteLine("4. Wyjście");
                Console.Write("\nWybierz opcję: ");

                var wybor = Console.ReadLine();

                switch (wybor)
                {
                    case "1":
                        DodajQuiz(quizSerwis);
                        break;
                    case "2":
                        WyswietlQuizy(quizSerwis);
                        break;
                    case "3":
                        UsunQuiz(quizSerwis);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór!");
                        break;
                }

                Console.WriteLine("\nNaciśnij dowolny klawisz...");
                Console.ReadKey();
            }
        }

        static void DodajQuiz(QuizSerwis serwis)
        {
            Console.Write("\nPodaj nazwę quizu: ");
            var nazwa = Console.ReadLine();

            Console.Write("Podaj opis quizu: ");
            var opis = Console.ReadLine();

            var quiz = new Quiz
            {
                Nazwa = nazwa,
                Opis = opis
            };

            serwis.DodajQuiz(quiz);
            Console.WriteLine("\n✓ Quiz został dodany!");
        }

        static void WyswietlQuizy(QuizSerwis serwis)
        {
            var quizy = serwis.PobierzWszystkieQuizy();

            Console.WriteLine("\n=== LISTA QUIZÓW ===");
            if (quizy.Count == 0)
            {
                Console.WriteLine("Brak quizów w bazie.");
                return;
            }

            foreach (var quiz in quizy)
            {
                Console.WriteLine($"\nID: {quiz.Id}");
                Console.WriteLine($"Nazwa: {quiz.Nazwa}");
                Console.WriteLine($"Opis: {quiz.Opis}");
                Console.WriteLine($"Liczba pytań: {quiz.Pytania.Count}");
            }
        }

        static void UsunQuiz(QuizSerwis serwis)
        {
            WyswietlQuizy(serwis);
            Console.Write("\nPodaj ID quizu do usunięcia: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                serwis.UsunQuiz(id);
                Console.WriteLine("\n✓ Quiz został usunięty!");
            }
            else
            {
                Console.WriteLine("\n✗ Nieprawidłowe ID!");
            }
        }
    }
}