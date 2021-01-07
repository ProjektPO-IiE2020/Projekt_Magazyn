using System;
using System.Collections.Generic;
using System.Globalization;
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
        DateTime _dataProdukcji;
        DateTime _dataPrzydatnosci;
        double _waga;
        private string v1;
        private object kosmetyki;
        private int v2;

        public string Kod { get => _kod; set => _kod = value; }
        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public Typy Typ { get => _typ; set => _typ = value; }
        public double Cena { get => _cena; set => _cena = value; }
        public static int OstatniKod { get => _ostatniKod; set => _ostatniKod = value; }
        public DateTime DataProdukcji { get => _dataProdukcji; set => _dataProdukcji = value; }
        public DateTime DataPrzydatnosci { get => _dataPrzydatnosci; set => _dataPrzydatnosci = value; }
        public double Waga { get => _waga; set => _waga = value; }

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
            _dataProdukcji = DateTime.MinValue;
            _dataProdukcji = DateTime.MinValue;
            _waga = 0;
        }
        public Towar(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, double waga) : this()
        {
            _kod = $"{_ostatniKod}-PS";
            _nazwa = nazwa;
            _typ = typ;
            _cena = cena;
            DateTime.TryParseExact(dataProdukcji, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out _dataProdukcji);
            DateTime.TryParseExact(dataPrzydatnosci, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out _dataPrzydatnosci);

            _waga = waga;
        }

        public Towar(string v1, object kosmetyki, int v2)
        {
            this.v1 = v1;
            this.kosmetyki = kosmetyki;
            this.v2 = v2;
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

        internal Towar Clone()
        {
            throw new NotImplementedException();
        }
    }
}
