﻿using System;
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

        public Dodaj_Towar(TowarEksport tE) : this()
        {
            _towar = tE;
            text_Nazwa.Text = _towar.Nazwa;
            text_Cena.Text = _towar.Cena.ToString();
            text_DataProdukcji.Text = _towar.DataProdukcji.ToString("dd.MM.yyyy");
            text_DataWaznosci.Text = _towar.DataPrzydatnosci.ToString("dd.MM.yyyy"); 
            
            if (_towar.Kraj == Kraje.Brazylia)
            {
                combo_kraj.SelectedIndex = 0;
            }
            else if (_towar.Kraj == Kraje.Norwegia)
            {
                combo_kraj.SelectedIndex = 1;
            }
            else if (_towar.Kraj == Kraje.Egipt)
            {
                combo_kraj.SelectedIndex = 2;
            }
            else if (_towar.Kraj == Kraje.Rosja)
            {
                combo_kraj.SelectedIndex = 3;
            }
            else if (_towar.Kraj == Kraje.Niemcy)
            {
                combo_kraj.SelectedIndex = 4;
            }
            else if (_towar.Kraj == Kraje.Hiszpania)
            {
                combo_kraj.SelectedIndex = 5;
            }
            else if (_towar.Kraj == Kraje.inny)
            {
                combo_kraj.SelectedIndex = 6;
            }

            if (_towar.Typ == Typy.napoje)
            {
                combo_typ.SelectedIndex = 0;
            }
            else if (_towar.Typ == Typy.warzywa)
            {
                combo_typ.SelectedIndex = 1;
            }
            else if (_towar.Typ == Typy.owoce)
            {
                combo_typ.SelectedIndex = 2;
            }
            else if (_towar.Typ == Typy.mięso)
            {
                combo_typ.SelectedIndex = 3;
            }
            else if (_towar.Typ == Typy.słodycze)
            {
                combo_typ.SelectedIndex = 4;
            }
            else if (_towar.Typ == Typy.chemia)
            {
                combo_typ.SelectedIndex = 5;
            }
            else if (_towar.Typ == Typy.inne)
            {
                combo_typ.SelectedIndex = 6;
            }
        }

        public Dodaj_Towar(TowarImport tI) : this()
        {
            _towar = tI;
            text_Nazwa.Text = _towar.Nazwa;
            text_Cena.Text = _towar.Cena.ToString();
            text_DataProdukcji.Text = _towar.DataProdukcji.ToString("dd.MM.yyyy");
            text_DataWaznosci.Text = _towar.DataPrzydatnosci.ToString("dd.MM.yyyy");
        }

        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (text_Nazwa.Text != "" && text_DataProdukcji.Text != "" && text_DataWaznosci.Text != "" && text_Cena.Text != "" && combo_kraj.Text != "" && combo_typ.Text != "")
            {
                string[] formatDaty = { "dd.MM.yyyy" };
                DateTime.TryParseExact(text_DataProdukcji.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataPr);
                DateTime.TryParseExact(text_DataWaznosci.Text, formatDaty, null, System.Globalization.DateTimeStyles.None, out DateTime dataWaz);
                _towar.Cena = Convert.ToDouble(text_Cena.Text);

                double cenaPom = Convert.ToDouble(_towar.Cena);
                if (cenaPom < 0)
                {
                    string message = "Cena nie może być ujemna!";
                    string title = "Niepoprawna cena";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                    return;
                }
                if (dataPr > dataWaz)
                {
                    string message = "Data przydatności nie powinna być datą wcześniejszą niż data produkcji";
                    string title = "Niepoprawne dane";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                    return;
                }
                if (dataPr.Year == 1 || dataWaz.Year == 1)
                {
                    string message = "Data powinna zostać wpisana w formacie dd.MM.yyyy";
                    string title = "Niepoprawny format daty";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                    return;
                }
                else
                {
                    _towar.Nazwa = text_Nazwa.Text;
                    _towar.DataProdukcji = dataPr;
                    _towar.DataPrzydatnosci = dataWaz;

                    if (combo_kraj.Text == "Brazylia")
                    {
                        _towar.Kraj = Kraje.Brazylia;
                    }
                    else if (combo_kraj.Text == "Egipt")
                    {
                        _towar.Kraj = Kraje.Egipt;
                    }
                    else if (combo_kraj.Text == "Hiszpania")
                    {
                        _towar.Kraj = Kraje.Hiszpania;
                    }
                    else if (combo_kraj.Text == "Niemcy")
                    {
                        _towar.Kraj = Kraje.Niemcy;
                    }
                    else if (combo_kraj.Text == "Norwegia")
                    {
                        _towar.Kraj = Kraje.Norwegia;
                    }
                    else if (combo_kraj.Text == "Rosja")
                    {
                        _towar.Kraj = Kraje.Rosja;
                    }
                    else if (combo_kraj.Text == "inny")
                    {
                        _towar.Kraj = Kraje.inny;
                    }

                    if (combo_typ.Text == "chemia")
                    {
                        _towar.Typ = Typy.chemia;
                    }
                    else if (combo_typ.Text == "mięso")
                    {
                        _towar.Typ = Typy.mięso;
                    }
                    else if (combo_typ.Text == "napoje")
                    {
                        _towar.Typ = Typy.napoje;
                    }
                    else if (combo_typ.Text == "owoce")
                    {
                        _towar.Typ = Typy.owoce;
                    }
                    else if (combo_typ.Text == "słodycze")
                    {
                        _towar.Typ = Typy.słodycze;
                    }
                    else if (combo_typ.Text == "warzywa")
                    {
                        _towar.Typ = Typy.warzywa;
                    }
                    else if (combo_typ.Text == "inne")
                    {
                        _towar.Typ = Typy.inne;
                    }
                    if (_towar is TowarEksport)
                    {
                        _towar.Kod = $"{_towar.OstatniKod}/{_towar.Kraj.ToString().Substring(0, 3).ToUpper()}/EX";
                    }
                    else
                    {
                        _towar.Kod = $"{_towar.OstatniKod}/{_towar.Kraj.ToString().Substring(0, 3).ToUpper()}/IM";
                    }
                    DialogResult = true;

                }
            }
        }
    }
}
