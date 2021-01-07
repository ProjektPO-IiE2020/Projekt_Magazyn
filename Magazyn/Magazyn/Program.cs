using Magazyn.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public enum Typy {napoje, warzywa, owoce, mięso, słodycze, inne};
    class Program
    {
        static void Main(string[] args)
        {
            Towar p1 = new Towar("Pepsi", Typy.napoje, 1.99, "21.10.2020", "21.03.2021");
            Towar p2 = new Towar("Dlugopis", Typy.inne, 3);
            Towar p3 = new Towar("Nivea", Typy.owoce, 111);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            TowarPromocyjny pp1 = new TowarPromocyjny("Buty", Typy.warzywa, 10, 400);
            TowarPromocyjny pp2 = new TowarPromocyjny("Inne buty", Typy.napoje, 2, 30);
            TowarPromocyjny pp3 = new TowarPromocyjny("inne inne", Typy.inne, 8, 15.5);
            Console.WriteLine();
            Console.WriteLine(pp1);
            Console.WriteLine(pp2);
            Console.WriteLine(pp3);
            Console.WriteLine();
            Magazyn magazyn = new Magazyn();
            magazyn.Umiesc(pp1);
            magazyn.Umiesc(pp2);
            magazyn.Umiesc(pp3);
            magazyn.Umiesc(p1);
            magazyn.Umiesc(p2);
            magazyn.Umiesc(p3);
            Console.WriteLine(magazyn.ToString());

            Console.WriteLine(p1.Kod);
            magazyn.UsunTowar(p1.Kod);
            Console.WriteLine();
            Console.WriteLine(magazyn.ToString());
            Console.WriteLine();

            Console.WriteLine();
            List<Towar> lista = new List<Towar>();
            lista = magazyn.ZnajdzTowar(Typy.inne);
            foreach (var v in lista)
                Console.WriteLine(v);
            Console.WriteLine();
            List<TowarPromocyjny> lista1 = new List<TowarPromocyjny>();
            lista1 = magazyn.ZnajdzTowaryPromocyjne();
            foreach (var v in lista1)
                Console.WriteLine(v);
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
            magazyn.ZapiszXML("Zapisany.xml");
            Console.WriteLine();
            ls2 = Magazyn.OdczytajXML("Zapisany.xml");
            Console.WriteLine(ls2.ToString());
            Console.ReadKey();
        }
    }
}
