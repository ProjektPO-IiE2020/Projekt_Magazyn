using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    interface IMagazynujeI
    {
        void Umiesc(TowarImport t);
        TowarImport Pobierz();
        void Wyczysc();
        int PodajIlosc();
        TowarImport PodajBiezacy();
        bool UsunTowar(string kod);
        List<TowarImport> ZnajdzTowar(Typy typ);
        TowarImport ZnajdzTowar(string kod);
        void SortujPoCenie();
        void SortujPoNazwie(bool f);
    }
}
