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
using Magazyn;

namespace MagazynGUI
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj_Towar.xaml
    /// </summary>
    public partial class Dodaj_Towar : Window
    {
        Towar _towar;
        public Dodaj_Towar()
        {
            InitializeComponent();
        }
        public Dodaj_Towar(Towar t) : this()
        {

        }
        

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
