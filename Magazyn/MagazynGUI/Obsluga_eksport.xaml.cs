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
    /// Logika interakcji dla klasy Obsluga_eksport.xaml
    /// </summary>
    public partial class Obsluga_eksport : Window
    {
        MagazynEksport _magazyn;
        public Obsluga_eksport()
        {
            InitializeComponent();
        }

        private void button_EKSPORT_dodaj_Click(object sender, RoutedEventArgs e)
        {
            TowarEksport t = new TowarEksport();
            Dodaj_Towar okno = new Dodaj_Towar(t);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                _magazyn.UmiescEksport(t);
                listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);// odświeżamy listę do wyświetlenia
            }
        }

        private void button_EKSPORT_usun_Click(object sender, RoutedEventArgs e)
        {
            if (_magazyn is object && listbox_EKSPORT.SelectedIndex > -1) // spr czy wybralismy jakis element
            {
                TowarEksport te = (TowarEksport)listbox_EKSPORT.SelectedItem;
                _magazyn.UsunTowarEksport(te.Kod);
                listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);
            }
        }

        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                _magazyn = MagazynEksport.OdczytajXMLEksport(filename);

                if (_magazyn is object)
                {
                    listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.ListaEksport);
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
                _magazyn.ZapiszXMLEksport(filename);
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listbox_EKSPORT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void text_EKSPORT_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button_EKSPORT_szukaj_Click(object sender, RoutedEventArgs e)
        {
            string wyszukaj = text_EKSPORT.Text;
            List<TowarEksport> znalezione = new List<TowarEksport>();
            foreach (TowarEksport t in _magazyn.ListaEksport)
            {
                if(t.Nazwa.ToLower().Contains(wyszukaj.ToLower()))
                {
                    znalezione.Add(t);
                }
            }
            listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(znalezione);

        }

        private void button_EKSPORT_odswiez_Click(object sender, RoutedEventArgs e)
        {
            listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.ListaEksport);
            text_EKSPORT.Clear();
        }

        private void button_EKSPORT_znajdz_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
