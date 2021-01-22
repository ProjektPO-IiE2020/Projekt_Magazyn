﻿using System;
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
    }
}
