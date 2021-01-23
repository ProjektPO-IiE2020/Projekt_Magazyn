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

        public Dodaj_Towar(Towar t) : this()
        {
            _towar = t;
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
                if (dataPr.Year == 1)
                {
                    string message = "Data urodzenia powinna zostać wpisana w formacie dd.MM.yyyy";
                    string title = "Niepoprawny format daty";
                    System.Windows.MessageBox.Show(message, title, MessageBoxButton.OK);
                }
                else
                {
                    _towar.Nazwa = text_Nazwa.Text;
                    _towar.Cena = Convert.ToDouble(text_Cena.Text);
                    _towar.DataProdukcji = dataPr;
                    _towar.DataPrzydatnosci = dataWaz;
                    if(combo_kraj.Text == "Brazylia")
                    {
                        _towar.Kraj = Kraje.Brazylia;
                    }
                    else if(combo_kraj.Text == "Egipt")
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

                    DialogResult = true; 
                }
            }
        }
    }
}
