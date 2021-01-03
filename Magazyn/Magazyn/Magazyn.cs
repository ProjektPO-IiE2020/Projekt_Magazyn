﻿using Magazyn.Properties;
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
    class Magazyn : IMagazynuje
    {
        string nazwa;
        int iloscTowarow;
        private Queue<Towar> _kolejkaTowaru;
        public List<Towar> _listaPom;

        internal Queue<Towar> KolejkaTowaru { get => _kolejkaTowaru; set => _kolejkaTowaru = value; }
        internal List<Towar> ListaPom { get => _listaPom; set => _listaPom = value; }

        public string Nazwa { get => nazwa; set => nazwa = value; }

        public Magazyn()
        {
            Nazwa = string.Empty;
            iloscTowarow = 0;
            KolejkaTowaru = new Queue<Towar>();
            ListaPom = new List<Towar>();
        }

        public Magazyn(string nazwa) : this()
        {
            this.Nazwa = nazwa;
        }

        public void Umiesc(Towar t)
        {
            KolejkaTowaru.Enqueue(t);
            iloscTowarow++;
        }

        public Towar Pobierz()
        {
            if (iloscTowarow == 0)
            {
                return null;
            }
            --iloscTowarow;
            return KolejkaTowaru.Dequeue();
        }

        public void Wyczysc()
        {
            iloscTowarow = 0;
            KolejkaTowaru.Clear();
        }

        public int PodajIlosc()
        {
            return KolejkaTowaru.Count();
        }

        public Towar PodajBiezacy()
        {
            return KolejkaTowaru.Peek();
        }

        public bool UsunTowar(string kod)
        {
            Queue<Towar> nowa = new Queue<Towar>();
            bool f = false;
            foreach (Towar t in _kolejkaTowaru)
            {
                if (!t.Kod.Equals(kod))
                    nowa.Enqueue(t);
                else
                    f = true;
            }
            _kolejkaTowaru = nowa;
            return f;
        }

        public Towar ZnajdzTowar(string kod)
        {
            Towar t = new Towar();
            bool f = false;
            foreach (Towar tow in _kolejkaTowaru)
            {
                if (tow.Kod.Equals(kod))
                {
                    t = tow;
                    f = true;
                }
            }
            if (!f)
                throw new TowarNotFoundException();
            return t;

        }

        public List<TowarPromocyjny> ZnajdzTowaryPromocyjne()
        {
            List<TowarPromocyjny> list = new List<TowarPromocyjny>();
            foreach (Towar p in _kolejkaTowaru)
            {
                if (p is TowarPromocyjny)
                    list.Add((TowarPromocyjny)p);
            }
            return list.Count == 0 ? null : list;
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
                m.ListaPom = (List<Towar>)(xmls.Deserialize(sw));
            }
            m._kolejkaTowaru = new Queue<Towar>(m.ListaPom);
            return m;
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

  