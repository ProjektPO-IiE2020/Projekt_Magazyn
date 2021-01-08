using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public abstract class Towar : IComparable<Towar>, IEquatable<Towar>
    {
        string _nazwa;
        Typy _typ;
        double _cena;
        DateTime _dataProdukcji;
        DateTime _dataPrzydatnosci;

        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public Typy Typ { get => _typ; set => _typ = value; }
        public double Cena { get => _cena; set => _cena = value; }
        public DateTime DataProdukcji { get => _dataProdukcji; set => _dataProdukcji = value; }
        public DateTime DataPrzydatnosci { get => _dataPrzydatnosci; set => _dataPrzydatnosci = value; }

       

        public Towar()
        {
            _nazwa = null;
            _typ = Typy.inne;
            _cena = 0;
            _dataProdukcji = DateTime.MinValue;
            _dataProdukcji = DateTime.MinValue;
        }
        public Towar(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci) : this()
        {
            _nazwa = nazwa;
            _typ = typ;
            _cena = cena;
            DateTime.TryParseExact(dataProdukcji, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out _dataProdukcji);
            DateTime.TryParseExact(dataPrzydatnosci, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy" }, null, DateTimeStyles.None, out _dataPrzydatnosci);
        }

        public override string ToString()
        {
            return $"{_nazwa}, {_typ}  ({_cena:C})";
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
