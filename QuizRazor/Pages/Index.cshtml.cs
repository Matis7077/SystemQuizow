using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizCore.Modele;
using QuizCore.Serwisy;

namespace QuizRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuizSerwis _quizSerwis = new QuizSerwis();

        public List<Quiz> Quizy { get; set; }

        public void OnGet()
        {
            Quizy = _quizSerwis.PobierzWszystkieQuizy();
        }
    }
}