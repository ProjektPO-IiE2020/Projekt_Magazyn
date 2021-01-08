using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    interface IMagazynuje
    {
        void Umiesc(Towar t);
        Towar Pobierz();
        void Wyczysc();
        int PodajIlosc();
        Towar PodajBiezacy();
        bool UsunTowar(string kod);
        List<Towar> ZnajdzTowar(Typy typ);
        Towar ZnajdzTowarImport(string kod);
        Towar ZnajdzTowarEksport(string kod);
        void SortujPoCenie();
        void SortujPoNazwie(bool f);
    }
}
