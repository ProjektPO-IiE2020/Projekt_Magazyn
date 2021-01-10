using Magazyn;
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
    public class Magazyn : IMagazynuje, ICloneable
    {
        string nazwa;
        int iloscTowarow;
        private Queue<Towar> _kolejkaTowaru;
        private List<Towar> _listaPom;

        public Queue<Towar> KolejkaTowaru { get => _kolejkaTowaru; set => _kolejkaTowaru = value; }
        public List<Towar> ListaPom { get => _listaPom; set => _listaPom = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }

        public Magazyn()
        {
            nazwa = string.Empty;
            iloscTowarow = 0;
            _kolejkaTowaru = new Queue<Towar>();
            _listaPom = new List<Towar>();
        }

        public Magazyn(string nazwa) : this()
        {
            this.nazwa = nazwa;
        }

        public void Umiesc(Towar t)
        {
            _kolejkaTowaru.Enqueue(t);
            iloscTowarow++;
        }

        public Towar Pobierz()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return _kolejkaTowaru.Dequeue();
        }

        public void Wyczysc()
        {
            iloscTowarow = 0;
            _kolejkaTowaru.Clear();
        }

        public int PodajIlosc()
        {
            return _kolejkaTowaru.Count();
        }

        public Towar PodajBiezacy()
        {
            return _kolejkaTowaru.Peek();
        }

        public bool UsunTowarEksport(string kod)
        {
            Queue<Towar> nowa = new Queue<Towar>();
            bool f = false;
            foreach (TowarEksport t in _kolejkaTowaru)
            {
                if (!t.Kod.Equals(kod))
                    nowa.Enqueue(t);
                else
                    f = true;
            }
            _kolejkaTowaru = nowa;
            return f;
        }

        public bool UsunTowarImport(string kod)
        {
            Queue<Towar> nowa = new Queue<Towar>();
            bool f = false;
            foreach (TowarImport t in _kolejkaTowaru)
            {
                if (!t.Kod.Equals(kod))
                    nowa.Enqueue(t);
                else
                    f = true;
            }
            _kolejkaTowaru = nowa;
            return f;
        }

        public List<Towar> ZnajdzTowar(Typy typ)
        {
            List<Towar> lista = new List<Towar>();
            foreach (Towar t in _kolejkaTowaru)
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

        public TowarEksport ZnajdzTowarEksport(string kod)
        {
            foreach (TowarEksport t in _kolejkaTowaru)
            {
                if (t.Kod.Equals(kod))
                {
                    return t;
                }
            }
            throw new TowarNotFoundException();
        }

        public TowarImport ZnajdzTowarImport(string kod)
        {
            foreach (TowarImport t in _kolejkaTowaru)
            {
                if (t.Kod == kod)
                {
                    return t;
                }
            }
            throw new TowarNotFoundException();
        }

        public void SortujPoCenie()
        {
            List<Towar> nowa = new List<Towar>(_kolejkaTowaru);
            nowa.Sort();
            _kolejkaTowaru = new Queue<Towar>(nowa);
        }


        public void SortujPoNazwie(bool f)
        {
            List<Towar> nowa = new List<Towar>(_kolejkaTowaru);
            nowa.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            if (f)
                nowa.Reverse();
            _kolejkaTowaru = new Queue<Towar>(nowa);
        }

        public void ZapiszXML(string nazwaPliku)
        {
            ListaPom = new List<Towar>(_kolejkaTowaru);
            XmlSerializer xmls = new XmlSerializer(typeof(List<Towar>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, ListaPom);
            }
        }

        public static Magazyn OdczytajXML(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            Magazyn m = new Magazyn();
            XmlSerializer xmls = new XmlSerializer(typeof(List<Towar>));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                m._listaPom = (List<Towar>)(xmls.Deserialize(sw));
            }
            m._kolejkaTowaru = new Queue<Towar>(m._listaPom);
            return m;
        }

        public object Clone()
        {
            Magazyn nowyMagazyn = new Magazyn();
            foreach (Towar t in _kolejkaTowaru)
            {
                nowyMagazyn._kolejkaTowaru.Enqueue(t.Clone());
            }
            return nowyMagazyn;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Magazyn: {Nazwa}");
            foreach (Towar t in KolejkaTowaru)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

    }
}

  