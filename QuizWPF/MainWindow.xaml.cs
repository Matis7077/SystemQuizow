using System.Windows;
using System.Windows.Controls;
using QuizCore.Modele;
using QuizCore.Serwisy;

namespace QuizWPF
{
    public partial class MainWindow : Window
    {
        private QuizSerwis quizSerwis = new QuizSerwis();
        private PytanieSerwis pytanieSerwis = new PytanieSerwis();
        private OdpowiedzSerwis odpowiedzSerwis = new OdpowiedzSerwis();

        public MainWindow()
        {
            InitializeComponent();
            ZaladujQuizy();
        }

        private void ZaladujQuizy()
        {
            var quizy = quizSerwis.PobierzWszystkieQuizy();
            ComboQuizy.ItemsSource = quizy;

            if (quizy.Count > 0)
            {
                ComboQuizy.SelectedIndex = 0;
            }
        }

        private void ComboQuizy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboQuizy.SelectedItem is Quiz wybranyQuiz)
            {
                ZaladujPytania(wybranyQuiz.Id);
            }
        }

        private void ZaladujPytania(int quizId)
        {
            var pytania = pytanieSerwis.PobierzPytaniaDlaQuizu(quizId);
            ListaPytan.Items.Clear();

            foreach (var pytanie in pytania)
            {
                var tekstPytania = $"Pytanie: {pytanie.TrescPytania}";
                ListaPytan.Items.Add(tekstPytania);

                foreach (var odp in pytanie.Odpowiedzi)
                {
                    var znacznik = odp.CzyPoprawna ? "✓" : "✗";
                    ListaPytan.Items.Add($"  {znacznik} {odp.TrescOdpowiedzi}");
                }

                ListaPytan.Items.Add(""); // Pusta linia
            }
        }

        private void BtnDodajPytanie_Click(object sender, RoutedEventArgs e)
        {
            if (ComboQuizy.SelectedItem is not Quiz wybranyQuiz)
            {
                TxtStatus.Text = "Wybierz quiz!";
                TxtStatus.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtPytanie.Text))
            {
                TxtStatus.Text = "Wprowadź treść pytania!";
                TxtStatus.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            // Utwórz pytanie
            var pytanie = new Pytanie
            {
                TrescPytania = TxtPytanie.Text,
                QuizId = wybranyQuiz.Id
            };

            pytanieSerwis.DodajPytanie(pytanie);

            // Dodaj odpowiedzi
            DodajOdpowiedzJesliNiePusta(TxtOdp1.Text, ChkOdp1.IsChecked == true, pytanie.Id);
            DodajOdpowiedzJesliNiePusta(TxtOdp2.Text, ChkOdp2.IsChecked == true, pytanie.Id);
            DodajOdpowiedzJesliNiePusta(TxtOdp3.Text, ChkOdp3.IsChecked == true, pytanie.Id);
            DodajOdpowiedzJesliNiePusta(TxtOdp4.Text, ChkOdp4.IsChecked == true, pytanie.Id);

            // Wyczyść pola
            TxtPytanie.Clear();
            TxtOdp1.Clear();
            TxtOdp2.Clear();
            TxtOdp3.Clear();
            TxtOdp4.Clear();
            ChkOdp1.IsChecked = false;
            ChkOdp2.IsChecked = false;
            ChkOdp3.IsChecked = false;
            ChkOdp4.IsChecked = false;

            TxtStatus.Text = "✓ Pytanie zostało dodane!";
            TxtStatus.Foreground = System.Windows.Media.Brushes.Green;

            ZaladujPytania(wybranyQuiz.Id);
        }

        private void DodajOdpowiedzJesliNiePusta(string tresc, bool czyPoprawna, int pytanieId)
        {
            if (!string.IsNullOrWhiteSpace(tresc))
            {
                var odpowiedz = new Odpowiedz
                {
                    TrescOdpowiedzi = tresc,
                    CzyPoprawna = czyPoprawna,
                    PytanieId = pytanieId
                };
                odpowiedzSerwis.DodajOdpowiedz(odpowiedz);
            }
        }
    }
}