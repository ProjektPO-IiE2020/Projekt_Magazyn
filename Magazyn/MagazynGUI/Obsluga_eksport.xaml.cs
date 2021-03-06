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
        static internal MagazynEksport _magazyn;
        bool dodany = false;
        bool zmiany;
        public Obsluga_eksport()
        {
            InitializeComponent();
        }

        private void button_EKSPORT_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (dodany == false)
            {
                string message = "Najpierw otwórz plik z magazynem!";
                string title = "Najpierw otwórz";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }
            else
            {
                TowarEksport t = new TowarEksport();
                Dodaj_Towar okno = new Dodaj_Towar(t);
                bool? ret = okno.ShowDialog();
                if (ret == true)
                {
                    _magazyn.UmiescEksport(t);
                    listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);
                    zmiany = true;
                }
            }
        }

        private void button_EKSPORT_usun_Click(object sender, RoutedEventArgs e)
        {
            if (_magazyn is object && listbox_EKSPORT.SelectedIndex > -1)
            {
                TowarEksport te = (TowarEksport)listbox_EKSPORT.SelectedItem;
                _magazyn.UsunTowarEksport(te.Kod);
                listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);
                zmiany = true;
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
                    listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);
                    dodany = true;
                    zmiany = false;
                }
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            if (dodany == false)
            {
                string message = "Najpierw otwórz plik z magazynem!";
                string title = "Najpierw otwórz";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }
            else
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string filename = dlg.FileName;
                    _magazyn.ZapiszXMLEksport(filename);
                    zmiany = false;
                }
            }
        }

        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            if (zmiany == true)
            {
                string message = "Czy chcesz zapisać zmiany?";
                string title = "Zapis";

                if (MessageBox.Show(message, title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        _magazyn.ZapiszXMLEksport(filename);
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void button_EKSPORT_szukaj_Click(object sender, RoutedEventArgs e)
        {
            if (dodany == false)
            {
                string message = "Najpierw otwórz plik z magazynem!";
                string title = "Najpierw otwórz";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }
            else
            {
                string wyszukaj = text_EKSPORT.Text;
                List<TowarEksport> znalezione = new List<TowarEksport>();
                foreach (TowarEksport t in _magazyn.KolejkaEksport)
                {
                    if (t.Nazwa.ToLower().Contains(wyszukaj.ToLower()))
                    {
                        znalezione.Add(t);
                    }
                }
                listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(znalezione);
            }

        }

        private void button_EKSPORT_odswiez_Click(object sender, RoutedEventArgs e)
        {
            if (dodany == false)
            {
                string message = "Najpierw otwórz plik z magazynem!";
                string title = "Najpierw otwórz";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }
            else
            {
                listbox_EKSPORT.ItemsSource = new ObservableCollection<TowarEksport>(_magazyn.KolejkaEksport);
                text_EKSPORT.Clear();
            }
        }

        private void button_EKSPORT_znajdz_Click(object sender, RoutedEventArgs e)
        {
            if (dodany == false)
            {
                string message = "Najpierw otwórz plik z magazynem!";
                string title = "Najpierw otwórz";
                System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                return;
            }
            else
            {
                Sort_Eksport okno = new Sort_Eksport();
                bool? ret = okno.ShowDialog();

            }
        }
    }
}
