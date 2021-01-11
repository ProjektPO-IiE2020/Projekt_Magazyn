using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    interface IMagazynujeI
    {
        void UmiescImport(TowarImport t);
        TowarImport PobierzImport();
        void WyczyscImport();
        int PodajIloscImport();
        TowarImport PodajBiezacyImport();
        bool UsunTowarImport(string kod);
        List<TowarImport> ZnajdzTowarImport(Typy typ);
        TowarImport ZnajdzTowarImport(string kod);
        void SortujPoCenieImport();
        void SortujPoNazwieImport(bool f);
    }
}
