using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    interface IMagazynujeE
    {
        void Umiesc(TowarEksport t);
        TowarEksport Pobierz();
        void Wyczysc();
        int PodajIlosc();
        TowarEksport PodajBiezacy();
        bool UsunTowar(string kod);
        List<TowarEksport> ZnajdzTowar(Typy typ);
        TowarEksport ZnajdzTowar(string kod);
        void SortujPoCenie();
        void SortujPoNazwie(bool f);
    }
}
