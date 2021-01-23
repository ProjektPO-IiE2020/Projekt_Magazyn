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
                    listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.KolejkaImport);
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


        private void button_IMPORT_usun_Click(object sender, RoutedEventArgs e)
        {
            if (_magazyn is object && listbox_IMPORT.SelectedIndex > -1)
            {
                TowarImport ti = (TowarImport)listbox_IMPORT.SelectedItem;
                _magazyn.UsunTowarImport(ti.Kod);
                listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.KolejkaImport);
            }
        }

        private void button_IMPORT_dodaj_Click_1(object sender, RoutedEventArgs e)
        {
            TowarImport t = new TowarImport();
            Dodaj_Towar okno = new Dodaj_Towar(t);
            bool? ret = okno.ShowDialog();
            if (ret == true)
            {
                _magazyn.UmiescImport(t);
                listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.KolejkaImport);// odświeżamy listę do wyświetlenia
            }
        }

        private void button_IMPORT_odswiez_Click(object sender, RoutedEventArgs e)
        {
            listbox_IMPORT.ItemsSource = new ObservableCollection<TowarImport>(_magazyn.KolejkaImport);
            text_IMPORT.Clear();
        }

        private void button_IMPORT_szukaj_Click(object sender, RoutedEventArgs e)
        {
            string wyszukaj = text_IMPORT.Text;
            List<TowarImport> znalezione = new List<TowarImport>();
            foreach (TowarImport t in _magazyn.KolejkaImport)
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
