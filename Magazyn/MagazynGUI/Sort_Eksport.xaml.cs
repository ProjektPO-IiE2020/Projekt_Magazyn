using System;
using System.Collections;
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
    /// Logika interakcji dla klasy Search_Sort_Edit.xaml
    /// </summary>
    public partial class Sort_Eksport : Window
    {
        public Sort_Eksport()
        {
            InitializeComponent();
            listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
        }
        private void btn_Wyjscie_Eksport_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void btn_Sortuj_Eksport_Click(object sender, RoutedEventArgs e)
        {
            if (combo_Sort_Eksport.Text == "Sortuj po nazwie")
            {
                Obsluga_eksport._magazyn.SortujPoNazwieEksport(false);
                listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }

            if (combo_Sort_Eksport.Text == "Sortuj po dacie produkcji")
            {
                Obsluga_eksport._magazyn.SortujPoDacieProdukcjiEksport(false);
                listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }

            if (combo_Sort_Eksport.Text == "Sortuj po dacie ważności")
            {
                Obsluga_eksport._magazyn.SortujPoDaciePrzydatnosciEksport(false);
                listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }
            if (combo_Sort_Eksport.Text == "Sortuj po cenie")
            {
                Obsluga_eksport._magazyn.SortujPoCenieEksport();
                listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }
        }
        private void btn_Wyszukaj_Eksport_Click(object sender, RoutedEventArgs e)
        {
            string wyszukaj = txt_Sort_Eksport.Text;
            List<TowarEksport> znalezione = new List<TowarEksport>();
            foreach (TowarEksport t in Obsluga_eksport._magazyn.KolejkaEksport)
            {
                if (t.Nazwa.ToLower().Contains(wyszukaj.ToLower()) || t.Kod.ToLower().Contains(wyszukaj.ToLower())
                    || t.Typ.ToString().ToLower().Contains(wyszukaj.ToLower()) || t.Kraj.ToString().ToLower().Contains(wyszukaj.ToLower()))
                {
                    znalezione.Add(t);
                }
            }
            listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(znalezione);
        }
        private void btn_Odswiez_Eksport_Click(object sender, RoutedEventArgs e)
        {
            listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            txt_Sort_Eksport.Clear();
        }
        private void btn_Termin_Eksport_Click(object sender, RoutedEventArgs e)
        {
            List<TowarEksport> znalezione = new List<TowarEksport>();
            foreach (TowarEksport t in Obsluga_eksport._magazyn.KolejkaEksport)
            {
                if (t.DataPrzydatnosci < DateTime.Today)
                {
                    znalezione.Add(t);
                }
            }
            listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(znalezione);
        }

        private void btn_Edytuj_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_Sort_Eksport.SelectedIndex > -1)
            {
                Dodaj_Towar okno = new Dodaj_Towar((TowarEksport)listbox_Sort_Eksport.SelectedItem);
                okno.ShowDialog();
                listbox_Sort_Eksport.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }
        }
    }
}
