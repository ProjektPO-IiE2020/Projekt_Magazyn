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
        bool UsunTowarEksport(string kod);
        bool UsunTowarImport(string kod);
        List<Towar> ZnajdzTowar(Typy typ);
        TowarImport ZnajdzTowarImport(string kod);
        TowarEksport ZnajdzTowarEksport(string kod);
        void SortujPoCenie();
        void SortujPoNazwie(bool f);
    }
}
