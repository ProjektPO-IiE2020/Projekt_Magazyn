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
            TowarEksport p4 = new TowarEksport("Żelki Zozole", Typy.słodycze, 7.99, "24.10.2020", "12.09.2022", Kraje.Niemcy);
            TowarEksport p5 = new TowarEksport("Antrykot", Typy.mięso, 0.99, "12.01.2021", "02.02.2020", Kraje.Niemcy);
            TowarEksport p6 = new TowarEksport("Żel pod prysznic", Typy.chemia, 3.89, "04.06.2020", "16.02.2023", Kraje.Rosja);
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
            Console.WriteLine(p4);
            Console.WriteLine(p5);
            Console.WriteLine(p6);

            TowarImport pp1 = new TowarImport("Ziemniaki", Typy.warzywa, 5.99, "13.06.2020", "11.03.2021", Kraje.Egipt);
            TowarImport pp2 = new TowarImport("Sok pomarańczowy", Typy.napoje, 3.49, "26.12.2020", "21.02.2021", Kraje.Brazylia);
            TowarImport pp3 = new TowarImport("Proszek do prania", Typy.chemia, 21.99, "07.02.2020", "15.03.2021", Kraje.Niemcy);
            TowarImport pp4 = new TowarImport("Zapach samochodowy", Typy.inne, 5.99, "13.02.2020", "12.09.2023", Kraje.Brazylia);
            TowarImport pp5 = new TowarImport("Ligawa", Typy.mięso, 3.49, "26.01.2020", "13.02.2021", Kraje.Niemcy);
            TowarImport pp6 = new TowarImport("Czekolada mleczna", Typy.słodycze, 21.99, "17.02.2020", "21.10.2021", Kraje.Norwegia);
            Console.WriteLine();
            Console.WriteLine(pp1);
            Console.WriteLine(pp2);
            Console.WriteLine(pp3);
            Console.WriteLine(pp4);
            Console.WriteLine(pp5);
            Console.WriteLine(pp6);
            Console.WriteLine();

            MagazynEksport eksport = new MagazynEksport();
            eksport.UmiescEksport(p1);
            eksport.UmiescEksport(p2);
            eksport.UmiescEksport(p3);
            eksport.UmiescEksport(p4);
            eksport.UmiescEksport(p5);
            eksport.UmiescEksport(p6);
            Console.WriteLine(eksport.ToString());

            MagazynImport import = new MagazynImport();
            import.UmiescImport(pp1);
            import.UmiescImport(pp2);
            import.UmiescImport(pp3);
            import.UmiescImport(pp4);
            import.UmiescImport(pp5);
            import.UmiescImport(pp6);
            Console.WriteLine(import.ToString());

            eksport.UsunTowarEksport(p1.Kod);
            Console.WriteLine();

            Console.WriteLine(eksport.ToString());
            
            Console.WriteLine();
            Console.WriteLine();

            List<TowarImport> lista = new List<TowarImport>();
            lista = import.ZnajdzTowarImport(Typy.chemia);
            foreach (var v in lista)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine();

            Towar t = eksport.ZnajdzTowarEksport(p2.Kod);
            Console.WriteLine(t);
            Console.WriteLine();
            eksport.SortujPoCenieEksport();
            Console.WriteLine(eksport.ToString());

            Console.WriteLine();
            import.SortujPoNazwieImport(false);
            Console.WriteLine(import.ToString());

            Console.WriteLine();
            eksport.SortujPoNazwieEksport(true);
            Console.WriteLine(eksport.ToString());

            MagazynEksport ls1 = new MagazynEksport();
            MagazynEksport ls2 = new MagazynEksport();
            MagazynEksport ls3 = new MagazynEksport();
            Console.WriteLine();
            Console.WriteLine("Kopiowanie");
            ls3 = (MagazynEksport)ls1.CloneEksport();
            Console.WriteLine(ls3.ToString());
            Console.WriteLine();
            Console.WriteLine("XML");
            eksport.ZapiszXMLEksport("MagazynE.xml");
            Console.WriteLine();
            ls2 = MagazynEksport.OdczytajXMLEksport("MagazynE.xml");
            Console.WriteLine(ls2.ToString());

            Console.ReadKey();
        }
    }
}
