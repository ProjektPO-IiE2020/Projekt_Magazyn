using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy Obsluga_import.xaml
    /// </summary>
    public partial class Obsluga_import : Window
    {
        MagazynImport _magazyn;
        public Obsluga_import()
        {
            InitializeComponent();
        }
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                _magazyn = MagazynImport.OdczytajXMLImport(filename);

                if (_magazyn is object)
                {
                    listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.ListaImport);
                }
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                _magazyn.ZapiszXMLImport(filename);
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_IMPORT_usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_IMPORT_dodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_IMPORT_dodaj_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void button_IMPORT_odswiez_Click(object sender, RoutedEventArgs e)
        {
            listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.ListaImport);
            text_IMPORT.Clear();
        }

        private void button_IMPORT_szukaj_Click(object sender, RoutedEventArgs e)
        {
            string wyszukaj = text_IMPORT.Text;
            List<TowarImport> znalezione = new List<TowarImport>();
            foreach (TowarImport t in _magazyn.ListaImport)
            {
                if (t.Nazwa.ToLower().Contains(wyszukaj.ToLower()))
                {
                    znalezione.Add(t);
                }
            }
            listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(znalezione);
        }
    }
}
