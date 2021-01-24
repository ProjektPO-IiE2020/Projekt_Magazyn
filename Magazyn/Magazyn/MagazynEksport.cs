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
    public class MagazynEksport : IMagazynujeE
    {
        string nazwa;
        int iloscTowarow;
        private Queue<TowarEksport> _kolejkaEksport;
        private List<TowarEksport> _listaEksport;

        public Queue<TowarEksport> KolejkaEksport { get => _kolejkaEksport; set => _kolejkaEksport = value; }
        public List<TowarEksport> ListaEksport { get => _listaEksport; set => _listaEksport = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }

        /// <summary>
        /// Niżej znajdują się funkcje niezbędne do obsługi magazynu towarów importowych
        /// </summary>
        public MagazynEksport()
        {
            nazwa = string.Empty;
            iloscTowarow = 0;
            _kolejkaEksport = new Queue<TowarEksport>();
            _listaEksport = new List<TowarEksport>();
        }

        public MagazynEksport(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }
        /// <summary>
        /// Funkcja "UmieśćEksport" pozwala na dodanie do magazynu towaru eksportowego
        /// </summary>
        /// <param name="t">dodawany towar</param>
        public void UmiescEksport(TowarEksport t)
        {
            _kolejkaEksport.Enqueue(t);
            iloscTowarow++;
        }
        /// <summary>
        /// Funkcja "PobierzEksport" pozwala na pobranie aktualnej listy towarów
        /// </summary>
        /// <returns>Zwraca listę towarów eksportowych znajdujących sie w magazynie</returns>
        public TowarEksport PobierzEksport()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return _kolejkaEksport.Dequeue();
        }
        /// <summary>
        /// Funkcja "WyczyśćEksport" usuwa wszystkie towary eksportowe z magazynu
        /// </summary>
        public void WyczyscEksport()
        {
            iloscTowarow = 0;
            _kolejkaEksport.Clear();
        }
        /// <summary>
        /// Funkcja "PodajIloscEksport" pozwala sprawdzić ile znajduje się towarów eksportowych w magazynie
        /// </summary>
        /// <returns>Ilość towarów eksportowych w magazynie</returns>
        public int PodajIloscEksport()
        {
            return _kolejkaEksport.Count();
        }
        /// <summary>
        /// Funkcja "PodajBiezacyEksport" pokazuje który produkt jest najdłużej w magazynie 
        /// </summary>
        /// <returns>Pierwszy produkt w kolejce towarów eksportowych</returns>
        public TowarEksport PodajBiezacyEksport()
        {
            return _kolejkaEksport.Peek();
        }
        /// <summary>
        /// Funkcja "UsunTowarEksport" pozwala na usunięcie danego towaru eksportowego po podaniu jego kodu
        /// </summary>
        /// <param name="kod">kod produktu eksportowego, ktory chcemy usunąć</param>
        /// <returns></returns>
        public bool UsunTowarEksport(string kod)
        {
            Queue<TowarEksport> nowa = new Queue<TowarEksport>();
            bool f = false;
            foreach (TowarEksport t in _kolejkaEksport)
            {
                if (!t.Kod.Equals(kod))
                    nowa.Enqueue(t);
                else
                    f = true;
            }
            _kolejkaEksport = nowa;
            return f;
        }
        /// <summary>
        /// Funkcja "ZnajdzTowarEksport" pozwala na wyszukanie produktów o wskazanym typie np. słodycze, mięso etc
        /// </summary>
        /// <param name="typ">Typ produktów, które chcemy wyświetlić</param>
        /// <returns>Lista towarów eksportowych o podanym typie</returns>
        public List<TowarEksport> ZnajdzTowarEksport(Typy typ)
        {
            List<TowarEksport> lista = new List<TowarEksport>();
            foreach (TowarEksport t in _kolejkaEksport)
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
        /// Funkcja "ZnajdzTowarEksport" pozwala na sprawdzenie i wyszukanie towaru po podaniu jego kodu
        /// </summary>
        /// <param name="kod">Kod szukanego towaru</param>
        /// <returns>Poszukiwany towar lub informacja o braku sprawdzanego towaru w magazynie</returns>
        public TowarEksport ZnajdzTowarEksport(string kod)
        {
            foreach (TowarEksport t in _kolejkaEksport)
            {
                if (t.Kod.Equals(kod))
                {
                    return t;
                }
            }
            throw new TowarNotFoundException();
        }
        /// <summary>
        /// Funkcja sortująca towary eksportowe po cenie (rosnąco)
        /// </summary>
        public void SortujPoCenieEksport()
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }
        /// <summary>
        /// Funkcja sortująca towary importowe po nazwie (alfabetycznie)
        /// </summary>
        /// <param name="f"></param>
        public void SortujPoNazwieEksport(bool f)
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            if (f)
                nowa.Reverse();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }
        /// <summary>
        /// Funkcja sortująca towary eksportowe po dacie produkcji (od najwcześniej wypordukowanego)
        /// </summary>
        /// <param name="f"></param>
        public void SortujPoDacieProdukcjiEksport(bool f)
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort((x, y) => x.DataProdukcji.CompareTo(y.DataProdukcji));
            if (f)
                nowa.Reverse();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }
        /// <summary>
        /// Funkcja sortująca towary eksportowe po dacie ważności w celu wydania produktów z magazynu w oparciu o zasadę FIFO
        /// </summary>
        /// <param name="f"></param>
        public void SortujPoDaciePrzydatnosciEksport(bool f)
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort((x, y) => x.DataPrzydatnosci.CompareTo(y.DataPrzydatnosci));
            if (f)
                nowa.Reverse();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }
        /// <summary>
        /// Funkcja umożliwiająca zapis listy towarów eksportowych do XML
        /// </summary>
        /// <param name="nazwaPliku">zapisany plik z listą towarów eksportowych</param>
        public void ZapiszXMLEksport(string nazwaPliku)
        {
            _listaEksport = new List<TowarEksport>(_kolejkaEksport);
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarEksport>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, _listaEksport);
            }
        }
        /// <summary>
        /// Funkcja służąca to otwarcia zapisanego pliku XML
        /// </summary>
        /// <param name="nazwaPliku">otwierany plik</param>
        /// <returns>Lista towarów eksportowych</returns>
        public static MagazynEksport OdczytajXMLEksport(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            MagazynEksport m = new MagazynEksport();
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarEksport>));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                m._listaEksport = (List<TowarEksport>)(xmls.Deserialize(sw));
            }
            m._kolejkaEksport = new Queue<TowarEksport>(m._listaEksport);
            return m;
        }
        /// <summary>
        /// Funkjca służąca klonowaniu listy towarów eksportowych
        /// </summary>
        /// <returns>Skolnowana lista towarów eksportowych</returns>
        public object CloneEksport()
        {
            MagazynEksport nowyMagazyn = new MagazynEksport();
            foreach (TowarEksport t in _kolejkaEksport)
            {
                nowyMagazyn._kolejkaEksport.Enqueue((TowarEksport)t.Clone());
            }
            return nowyMagazyn;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Magazyn Eksport: {Nazwa}");
            foreach (TowarEksport t in _kolejkaEksport)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }
    }
}
