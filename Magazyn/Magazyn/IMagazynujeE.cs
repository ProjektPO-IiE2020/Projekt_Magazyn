using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    interface IMagazynujeE
    {
        void UmiescEksport(TowarEksport t);
        TowarEksport PobierzEksport();
        void WyczyscEksport();
        int PodajIloscEksport();
        TowarEksport PodajBiezacyEksport();
        bool UsunTowarEksport(string kod);
        List<TowarEksport> ZnajdzTowarEksport(Typy typ);
        TowarEksport ZnajdzTowarEksport(string kod);
        void SortujPoCenieEksport();
        void SortujPoNazwieEksport(bool f);
    }
}
