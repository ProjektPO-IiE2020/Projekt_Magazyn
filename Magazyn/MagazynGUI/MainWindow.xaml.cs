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
using Magazyn;

namespace MagazynGUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MagazynEksport me = new MagazynEksport();
        MagazynImport mi = new MagazynImport();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void button_IMPORT_Click(object sender, RoutedEventArgs e)
        {
            Obsluga_import okno = new Obsluga_import();
            bool? ret = okno.ShowDialog();
        }

        private void button_EKSPORT_Click(object sender, RoutedEventArgs e)
        {
            Obsluga_eksport okno = new Obsluga_eksport();
            bool? ret = okno.ShowDialog();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
