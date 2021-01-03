using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Properties
{
    interface IMagazynuje
    {
        void Umiesc(Towar t);
        Towar Pobierz();
        void Wyczysc();
        int PodajIlosc();
        Towar PodajBiezacy();
    }
}
