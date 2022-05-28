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
using System.Windows.Shapes;

namespace SuperDuperMarkt
{
    /// <summary>
    /// Interaktionslogik für BestellInfoFenster.xaml
    /// </summary>
    public partial class BestellInfoFenster : Window
    {
        List<Produkt> Warenkorb = new List<Produkt>();
        Array a;

        public BestellInfoFenster(Array r)
        {
            InitializeComponent();
        }

    }
}
