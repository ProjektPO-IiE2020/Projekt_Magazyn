using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn.Properties
{
    [Serializable]
    public class Towar : IComparable<Towar>, IEquatable<Towar>
    {
        private string _kod;
        string _nazwa;
        Typy _typ;
        double _cena;
        static int _ostatniKod;

        public string Kod { get => _kod; set => _kod = value; }
        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public Typy typ { get => _typ; set => _typ = value; }
        public double Cena { get => _cena; set => _cena = value; }
        public static int OstatniKod { get => _ostatniKod; set => _ostatniKod = value; }

        static Towar()
        {
            _ostatniKod = 0;
        }

        public Towar()
        {
            ++_ostatniKod;
            _kod = null;
            _nazwa = null;
            _typ = Typy.inne;
            _cena = 0;
        }
        public Towar(string nazwa, Typy typ, double cena) : this()
        {
            _kod = $"{_ostatniKod}-PS";
            _nazwa = nazwa;
            _typ = typ;
            _cena = cena;
        }

        public override string ToString()
        {
            return $"{_kod}: {_nazwa}, {_typ}  ({_cena:C})";
        }

        public int CompareTo(Towar other)
        {
            return _cena.CompareTo(other.Cena);
        }

        public bool Equals(Towar other)
        {
            return (_nazwa.Equals(other.Nazwa) && _typ.Equals(other._typ));
        }

    }
}
