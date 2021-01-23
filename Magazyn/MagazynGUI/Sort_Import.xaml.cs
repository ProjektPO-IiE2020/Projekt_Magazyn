using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Magazyn;

namespace MagazynGUI
{
    /// <summary>
    /// Logika interakcji dla klasy Search_Sort_Edit.xaml
    /// </summary>
    public partial class Sort_Import : Window
    {
        public Sort_Import()
        {
            InitializeComponent();
            listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
        }
        private void btn_Wyjscie_Import_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void btn_Sortuj_Import_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Sort_Import.Text == "Sortuj po nazwie")
            {
                Obsluga_import._magazyn.SortujPoNazwieImport(false);
                listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            }

            if (combo_Sort_Import.Text == "Sortuj po dacie produkcji")
            {
                Obsluga_import._magazyn.SortujPoDacieProdukcjiImport(false);
                listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            }

            if (combo_Sort_Import.Text == "Sortuj po dacie ważności")
            {
                Obsluga_import._magazyn.SortujPoDaciePrzydatnosciImport(false);
                listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            }
            if (combo_Sort_Import.Text == "Sortuj po cenie")
            {
                Obsluga_import._magazyn.SortujPoCenieImport();
                listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            }
        }
        private void btn_Wyszukaj_Import_Click(object sender, RoutedEventArgs e)
        {
            string wyszukaj = txt_Sort_Import.Text;
            List<TowarImport> znalezione = new List<TowarImport>();
            foreach (TowarImport t in Obsluga_import._magazyn.KolejkaImport)
            {
                if (t.Nazwa.ToLower().Contains(wyszukaj.ToLower()) || t.Kod.ToLower().Contains(wyszukaj.ToLower())
                    || t.Typ.ToString().ToLower().Contains(wyszukaj.ToLower()) || t.Kraj.ToString().ToLower().Contains(wyszukaj.ToLower()))
                {
                    znalezione.Add(t);
                }
            }
            listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(znalezione);
        }
        private void btn_Odswiez_Import_Click(object sender, RoutedEventArgs e)
        {
            listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            txt_Sort_Import.Clear();
        }
        private void btn_Termin_Import_Click(object sender, RoutedEventArgs e)
        {
            List<TowarImport> znalezione = new List<TowarImport>();
            foreach (TowarImport t in Obsluga_import._magazyn.KolejkaImport)
            {
                if (t.DataPrzydatnosci < DateTime.Today)
                {
                    znalezione.Add(t);
                }
            }
            listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(znalezione);
        }

        private void btn_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_Sort_Import.SelectedIndex > -1)
            {
                Dodaj_Towar okno = new Dodaj_Towar((TowarImport)listbox_Sort_Import.SelectedItem);
                okno.ShowDialog();
                listbox_Sort_Import.ItemsSource = new ObservableCollection<TowarImport>(Obsluga_import._magazyn.KolejkaImport);
            }
        }
    }
}
