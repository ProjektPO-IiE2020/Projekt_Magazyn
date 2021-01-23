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
    public partial class Search_Sort_Edit : Window
    {
        public Search_Sort_Edit()
        {
            InitializeComponent();
            listbox_Search_Sort.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
        }

        private void btn_EKSPORT_wyjscie_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void btn_sortuj_Click(object sender, RoutedEventArgs e)
        {
            if (combo_sortowanie.Text == "Sortuj po nazwie")
            {
                Obsluga_eksport._magazyn.SortujPoNazwieEksport(false);
                listbox_Search_Sort.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }

            if (combo_sortowanie.Text == "Sortuj po dacie produkcji")
            {
                Obsluga_eksport._magazyn.SortujPoDacieProdukcjiEksport(false);
                listbox_Search_Sort.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }

            if (combo_sortowanie.Text == "Sortuj po dacie ważności")
            {
                Obsluga_eksport._magazyn.SortujPoDaciePrzydatnosciEksport(false);
                listbox_Search_Sort.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }
            if (combo_sortowanie.Text == "Sortuj po cenie")
            {
                Obsluga_eksport._magazyn.SortujPoCenieEksport();
                listbox_Search_Sort.ItemsSource = new ObservableCollection<TowarEksport>(Obsluga_eksport._magazyn.KolejkaEksport);
            }
        }
    }
}
