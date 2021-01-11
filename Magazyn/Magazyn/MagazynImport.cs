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
    class MagazynImport : IClonable
    {
        string nazwa;
        int iloscTowarow;
        private Queue<TowarImport> _kolejkaImport;
        private List<TowarImport> _listaImport;

        public Queue<TowarImport> KolejkaImport { get => _kolejkaImport; set => _kolejkaImport = value; }
        public List<TowarImport> ListaImport { get => _listaImport; set => _listaImport = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }

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

        public void UmiescImport(TowarImport t)
        {
            _kolejkaImport.Enqueue(t);
            iloscTowarow++;
        }

        public TowarImport PobierzImport()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return _kolejkaImport.Dequeue();
        }

        public void WyczyscImport()
        {
            iloscTowarow = 0;
            _kolejkaImport.Clear();
        }

        public int PodajIloscImport()
        {
            return _kolejkaImport.Count();
        }

        public TowarImport PodajBiezacyImport()
        {
            return _kolejkaImport.Peek();
        }

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

        public void SortujPoCenieImport()
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }


        public void SortujPoNazwieImport(bool f)
        {
            List<TowarImport> nowa = new List<TowarImport>(_kolejkaImport);
            nowa.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            if (f)
                nowa.Reverse();
            _kolejkaImport = new Queue<TowarImport>(nowa);
        }

        public void ZapiszXMLImport(string nazwaPliku)
        {
            _listaImport = new List<TowarImport>(_kolejkaImport);
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarImport>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, _listaImport);
            }
        }

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
