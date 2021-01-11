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
    public enum Kraje {Brazylia, Norwegia, Egipt, Rosja, Niemcy, Hiszpania, inny};
    class Program
    {
        static void Main(string[] args)
        {
            TowarEksport p1 = new TowarEksport("Pepsi", Typy.napoje, 7.99, "21.10.2020", "12.03.2021", Kraje.Rosja);
            TowarEksport p2 = new TowarEksport("Długopis", Typy.inne, 0.99, "12.11.2020", "22.03.2021", Kraje.Hiszpania);
            TowarEksport p3 = new TowarEksport("Jabłka", Typy.owoce, 3.89, "03.03.2020", "08.02.2021", Kraje.Norwegia);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);

            TowarImport pp1 = new TowarImport("Ziemniaki", Typy.warzywa, 5.99, "13.06.2020", "11.03.2021", Kraje.Egipt);
            TowarImport pp2 = new TowarImport("Sok pomarańczowy", Typy.napoje, 3.49, "26.12.2020", "21.02.2021", Kraje.Brazylia);
            TowarImport pp3 = new TowarImport("Proszek do prania", Typy.chemia, 21.99, "07.02.2020", "15.03.2021", Kraje.Niemcy);
            Console.WriteLine();
            Console.WriteLine(pp1);
            Console.WriteLine(pp2);
            Console.WriteLine(pp3);
            Console.WriteLine();

            MagazynEksport eksport = new MagazynEksport();
            eksport.Umiesc(p1);
            eksport.Umiesc(p2);
            eksport.Umiesc(p3);
            Console.WriteLine(eksport.ToString());

            MagazynImport import = new MagazynImport();
            import.Umiesc(pp1);
            import.Umiesc(pp2);
            import.Umiesc(pp3);
            Console.WriteLine(import.ToString());

            Console.WriteLine(p1.Kod);
            eksport.UsunTowar(p1.Kod);
            Console.WriteLine();

            Console.WriteLine(eksport.ToString());
            
            Console.WriteLine();
            Console.WriteLine();

            List<TowarImport> lista = new List<TowarImport>();
            lista = import.ZnajdzTowar(Typy.chemia);
            foreach (var v in lista)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();

            Towar t = eksport.ZnajdzTowar(p2.Kod);
            Console.WriteLine(t);
            Console.WriteLine();
            eksport.SortujPoCenie();
            Console.WriteLine(eksport.ToString());

            Console.WriteLine();
            import.SortujPoNazwie(false);
            Console.WriteLine(import.ToString());

            Console.WriteLine();
            eksport.SortujPoNazwie(true);
            Console.WriteLine(eksport.ToString());

            MagazynEksport ls1 = new MagazynEksport();
            MagazynEksport ls2 = new MagazynEksport();
            MagazynEksport ls3 = new MagazynEksport();
            Console.WriteLine(ls1.ToString());
            Console.WriteLine();
            Console.WriteLine("Kopiowanie");
            ls3 = (MagazynEksport)ls1.Clone();
            Console.WriteLine(ls3.ToString());
            Console.WriteLine();
            Console.WriteLine("XML");
            eksport.ZapiszXML("Magazyn.xml");
            Console.WriteLine();
            ls2 = MagazynEksport.OdczytajXML("Magazyn.xml");
            Console.WriteLine(ls2.ToString());

            Console.ReadKey();
        }
    }
}
