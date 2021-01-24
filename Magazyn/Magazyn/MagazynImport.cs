using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magazyn
{
    [Serializable]
    public class MagazynImport : IClonable
    {
        string nazwa;
        int iloscTowarow;
        private Queue<TowarImport> _kolejkaImport;
        private List<TowarImport> _listaImport;

        public Queue<TowarImport> KolejkaImport { get => _kolejkaImport; set => _kolejkaImport = value; }
        public List<TowarImport> ListaImport { get => _listaImport; set => _listaImport = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Niżej znajdują się funkcje niezbędne do obsługi magazynu towarów importowych
        /// </summary>
        public MagazynImport()
        {
            nazwa = string.Empty;
            iloscTowarow = 0;
            _kolejkaImport = new Queue<TowarImport>();
            _listaImport = new List<TowarImport>();
        }
        
        public MagazynImport(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }
        /// <summary>
        /// Funkcja "UmieśćImport" pozwala na dodanie do magazynu towaru importowego
        /// </summary>
        /// <param name="t">dodawany towar</param>
        public void UmiescImport(TowarImport t)
        {
            _kolejkaImport.Enqueue(t);
            iloscTowarow++;
        }
        /// <summary>
        /// Funkcja "PobierzImport" pozwala na pobranie aktualnej listy towarów
        /// </summary>
        /// <returns>Zwraca listę towarów importowych znajdujących sie w magazynie</returns>
        public TowarImport PobierzImport()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return _kolejkaImport.Dequeue();
        }
        /// <summary>
        /// Funkcja "WyczyśćImport" usuwa wszystkie towary importowe z magazynu 
        /// </summary>
        public void WyczyscImport()
        {
            iloscTowarow = 0;
            _kolejkaImport.Clear();
        }
        /// <summary>
        /// Funkcja "PodajIloscImport" pozwala sprawdzić ile znajduje się towarów impotowych w magazynie
        /// </summary>
        /// <returns>Ilość towarów importowych w magazynie</returns>
        public int PodajIloscImport()
        {
            return _kolejkaImport.Count();
        }
        /// <summary>
        /// Funkcja "PodajBiezacyImport" pokazuje który produkt jest najdłużej w magazynie 
        /// </summary>
        /// <returns>Pierwszy produkt w kolejce towarów importowych</returns>
        public TowarImport PodajBiezacyImport()
        {
            return _kolejkaImport.Peek();
        }
        /// <summary>
        /// Funkcja "UsunTowarImport" pozwala na usunięcie danego towaru importowego po podaniu jego kodu
        /// </summary>
        /// <param name="kod">kod produktu importowego, ktory chcemy usunąć</param>
        /// <returns>Jeśli towar był w magazynie i został usunięty zwraca prawdę, jeśli nie-fałsz</returns>
        public bool UsunTowarImport(string kod)
        {
            Queue<TowarImport> nowa = new Queue<TowarImport>();
            bool f = false;
            foreach (TowarImport t in _kolejkaImport)
            {
                if (!t.Kod.Equals(kod))
                    nowa.Enqueue(t);
                else
                    f = true;
            }
            _kolejkaImport = nowa;
            return f;
        }

        /// <summary>
        /// Funkcja "ZnajdzTowarImport" pozwala na wyszukanie produktów o wskazanym typie np. słodycze, mięso etc
        /// </summary>
        /// <param name="typ">Typ produktów, które chcemy wyświetlić</param>
        /// <returns>Lista towarów importowych o podanym typie</returns>
        public List<TowarImport> ZnajdzTowarImport(Typy typ)
        {
            List<TowarImport> lista = new List<TowarImport>();
            foreach (TowarImport t in _kolejkaImport)
            {
                if (t.Typ == typ)
                {
                    lista.Add(t);
                }
            }
            if (lista.Count != 0)
            {
                return lista;
            }
            return null;
        }
        /// <summary>
        /// Funkcja "ZnajdzTowarImport" pozwala na sprawdzenie i wyszukanie towaru po podaniu jego kodu
        /// </summary>
        /// <param name="kod">Kod szukanego towaru</param>
        /// <returns>Poszukiwany towar lub informacja o braku sprawdzanego towaru w magazynie</returns>
        public TowarImport ZnajdzTowarImport(string kod)
        {
            foreach (TowarImport t in _kolejkaImport)
            {
                if (t.Kod.Equals(kod))
                {
                    return t;
                }
            }
            throw new TowarNotFoundException();
        }
        /// <summary>
        /// Funkcja sortująca towary importowe po cenie (rosnąco)
        /// </summary>
        public void SortujPoCenieImport()
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }

        /// <summary>
        /// Funkcja sortująca towary importowe po nazwie (alfabetycznie)
        /// </summary>
        /// <param name="f">Odwracanie kolejności z powodu specyfikacji kolekcji kolejki</param>
        public void SortujPoNazwieImport(bool f)
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            if (f)
                nowa.Reverse();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }
        /// <summary>
        /// Funkcja sortująca towary importowe po dacie produkcji (od najwcześniej wypordukowanego)
        /// </summary>
        /// <param name="f">Odwracanie kolejności z powodu specyfikacji kolekcji kolejki</param>
        public void SortujPoDacieProdukcjiImport(bool f)
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort((x, y) => x.DataProdukcji.CompareTo(y.DataProdukcji));
            if (f)
                nowa.Reverse();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }
        /// <summary>
        /// Funkcja sortująca towary importowe po dacie ważności w celu wydania produktów z magazynu w oparciu o zasadę FIFO
        /// </summary>
        /// <param name="f">Odwracanie kolejności z powodu specyfikacji kolekcji kolejki</param>
        public void SortujPoDaciePrzydatnosciImport(bool f)
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort((x, y) => x.DataPrzydatnosci.CompareTo(y.DataPrzydatnosci));
            if (f)
                nowa.Reverse();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }
        /// <summary>
        /// Funkcja umożliwiająca zapis listy towarów importowych do XML
        /// </summary>
        /// <param name="nazwaPliku">zapisany plik z listą towarów importowych</param>
        public void ZapiszXMLImport(string nazwaPliku)
        {
            _listaImport = new List<TowarImport>(_kolejkaImport);
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarImport>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, _listaImport);
            }
        }
        /// <summary>
        /// Funkcja służąca to otwarcia zapisanego pliku XML
        /// </summary>
        /// <param name="nazwaPliku">otwierany plik</param>
        /// <returns>Lista towarów importowych</returns>
        public static MagazynImport OdczytajXMLImport(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            MagazynImport m = new MagazynImport();
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarImport>));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                m._listaImport = (List<TowarImport>)(xmls.Deserialize(sw));
            }
            m._kolejkaImport = new Queue<TowarImport>(m._listaImport);
            return m;
        }
        /// <summary>
        /// Funkcja służąca klonowaniu listy towarów importowych
        /// </summary>
        /// <returns>Sklonowana lista</returns>
        public object CloneImport()
        {
            MagazynImport nowyMagazyn = new MagazynImport();
            foreach (TowarImport t in _kolejkaImport)
            {
                nowyMagazyn._kolejkaImport.Enqueue((TowarImport)t.Clone());
            }
            return nowyMagazyn;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Magazyn Import: {Nazwa}");
            foreach (TowarImport t in _kolejkaImport)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }
    }
}
