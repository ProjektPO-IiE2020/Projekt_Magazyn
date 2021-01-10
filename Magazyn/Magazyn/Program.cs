using Magazyn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public enum Typy {napoje, warzywa, owoce, mięso, słodycze, chemia, inne};
    public enum Kraje {Brazylia, Norwegia, Egipt, Rosja, Niemcy, Hiszpania};
    class Program
    {
        static void Main(string[] args)
        {
            TowarEksport p1 = new TowarEksport("Pepsi", Typy.napoje, 1.99, "21.10.2020", "12.03.2021", Kraje.Rosja);
            TowarEksport p2 = new TowarEksport("Długopis", Typy.inne, 1.99, "12.11.2020", "22.03.2021", Kraje.Hiszpania);
            TowarEksport p3 = new TowarEksport("Jabłka", Typy.owoce, 1.99, "03.03.2020", "08.02.2021", Kraje.Norwegia);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            TowarImport pp1 = new TowarImport("Ziemniaki", Typy.warzywa, 1.99, "13.06.2020", "11.03.2021", Kraje.Egipt);
            TowarImport pp2 = new TowarImport("Sok pomarańczowy", Typy.napoje, 1.99, "26.12.2020", "21.02.2021", Kraje.Brazylia);
            TowarImport pp3 = new TowarImport("Proszek do prania", Typy.chemia, 1.99, "07.02.2020", "15.03.2021", Kraje.Niemcy);
            Console.WriteLine();
            Console.WriteLine(pp1);
            Console.WriteLine(pp2);
            Console.WriteLine(pp3);
            Console.WriteLine();

            Magazyn magazyn = new Magazyn();
            magazyn.Umiesc(p1);
            magazyn.Umiesc(p2);
            magazyn.Umiesc(p3);
            magazyn.Umiesc(pp1);
            magazyn.Umiesc(pp2);
            magazyn.Umiesc(pp3);
            Console.WriteLine(magazyn.ToString());

            Console.WriteLine(p1.Kod);
            

            Console.WriteLine("********************************************************************************************************");
            magazyn.UsunTowarEksport(p1.Kod);
            Console.WriteLine();

            Console.WriteLine(magazyn.ToString());
            
            Console.WriteLine();
            Console.WriteLine();

            List<Towar> lista = new List<Towar>();
            lista = magazyn.ZnajdzTowar(Typy.inne);
            foreach (var v in lista)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();

            TowarEksport t = magazyn.ZnajdzTowarEksport(p2.Kod);
            Console.WriteLine(t);
            Console.WriteLine();
            magazyn.SortujPoCenie();
            Console.WriteLine(magazyn.ToString());

            Console.WriteLine();
            magazyn.SortujPoNazwie(false);
            Console.WriteLine(magazyn.ToString());

            Console.WriteLine();
            magazyn.SortujPoNazwie(true);
            Console.WriteLine(magazyn.ToString());

            Magazyn ls1 = new Magazyn();
            Magazyn ls2 = new Magazyn();
            Magazyn ls3 = new Magazyn();
            Console.WriteLine(ls1.ToString());
            Console.WriteLine();
            Console.WriteLine("Kopiowanie");
            ls3 = (Magazyn)ls1.Clone();
            Console.WriteLine(ls3.ToString());
            Console.WriteLine();
            Console.WriteLine("XML");
            magazyn.ZapiszXML("Magazyn.xml");
            Console.WriteLine();
            ls2 = Magazyn.OdczytajXML("Magazyn.xml");
            Console.WriteLine(ls2.ToString()); 

            Console.ReadKey();
        }
    }
}
