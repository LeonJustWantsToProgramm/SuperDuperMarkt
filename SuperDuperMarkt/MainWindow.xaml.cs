using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuperDuperMarkt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Öffnet das Kundenerstellungsfenster
        private void KundenErstBtn_Click(object sender, RoutedEventArgs e)
        {
            KundenErstellen kundenErstellenObj = new KundenErstellen();
            kundenErstellenObj.Show();
        }

        // Öffnet das Bestellungsfenster
        private void BestellungAufgBtn_Click(object sender, RoutedEventArgs e)
        {
            Anmeldefenster anmeldefenster = new Anmeldefenster();
            anmeldefenster.Show();
        }

        // Öffnet das Produkterstellungsfenster
        private void ProduktErstellenBtn_Click(object sender, RoutedEventArgs e)
        {
            ProduktErstellen produktErstellenFenster = new ProduktErstellen();
            produktErstellenFenster.Show();
        }
    }
}
