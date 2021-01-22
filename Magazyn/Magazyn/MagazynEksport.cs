﻿using System;
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

        public void UmiescEksport(TowarEksport t)
        {
            _kolejkaEksport.Enqueue(t);
            iloscTowarow++;
        }

        public TowarEksport PobierzEksport()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return _kolejkaEksport.Dequeue();
        }

        public void WyczyscEksport()
        {
            iloscTowarow = 0;
            _kolejkaEksport.Clear();
        }

        public int PodajIloscEksport()
        {
            return _kolejkaEksport.Count();
        }

        public TowarEksport PodajBiezacyEksport()
        {
            return _kolejkaEksport.Peek();
        }

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


        public void SortujPoCenieEksport()
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }


        public void SortujPoNazwieEksport(bool f)
        {
            List<TowarEksport> nowa = new List<TowarEksport>(_kolejkaEksport);
            nowa.Sort((x, y) => x.Nazwa.CompareTo(y.Nazwa));
            if (f)
                nowa.Reverse();
            _kolejkaEksport = new Queue<TowarEksport>(nowa);
        }

        public void ZapiszXMLEksport(string nazwaPliku)
        {
            _listaEksport = new List<TowarEksport>(_kolejkaEksport);
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarEksport>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, _listaEksport);
            }
        }

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
