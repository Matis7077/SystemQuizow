using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizCore.Modele;
using QuizCore.Serwisy;

namespace QuizRazor.Pages
{
    public class QuizModel : PageModel
    {
        private readonly QuizSerwis _quizSerwis = new QuizSerwis();

        public Quiz Quiz { get; set; }
        public int? Wynik { get; set; }
        public bool CzyZakonczony { get; set; }

        public IActionResult OnGet(int id)
        {
            Quiz = _quizSerwis.PobierzQuizPoId(id);

            if (Quiz == null)
            {
                return Page();
            }

            return Page();
        }

        public IActionResult OnPost(int quizId)
        {
            Quiz = _quizSerwis.PobierzQuizPoId(quizId);

            if (Quiz == null)
            {
                return Page();
            }

            int poprawneOdpowiedzi = 0;

            foreach (var pytanie in Quiz.Pytania)
            {
                var wybranaOdpowiedzId = Request.Form[$"Pytanie_{pytanie.Id}"].ToString();

                if (int.TryParse(wybranaOdpowiedzId, out int odpId))
                {
                    var odpowiedz = pytanie.Odpowiedzi.FirstOrDefault(o => o.Id == odpId);
                    if (odpowiedz != null && odpowiedz.CzyPoprawna)
                    {
                        poprawneOdpowiedzi++;
                    }
                }
            }

            Wynik = poprawneOdpowiedzi;
            CzyZakonczony = true;

            return Page();
        }
    }
}