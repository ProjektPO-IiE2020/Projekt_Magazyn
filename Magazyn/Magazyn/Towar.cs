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
        static int _ostatniKod;
        string _kod;
        Kraje _kraj;

        public string Nazwa { get => _nazwa; set => _nazwa = value; }
        public Typy Typ { get => _typ; set => _typ = value; }
        public double Cena { get => _cena; set => _cena = value; }
        public DateTime DataProdukcji { get => _dataProdukcji; set => _dataProdukcji = value; }
        public DateTime DataPrzydatnosci { get => _dataPrzydatnosci; set => _dataPrzydatnosci = value; }
        public int OstatniKod { get => _ostatniKod; set => _ostatniKod = value; }
        public string Kod { get => _kod; set => _kod = value; }
        public Kraje Kraj { get => _kraj; set => _kraj = value; }

        public Towar()
        {
            ++_ostatniKod;
            _nazwa = null;
            _typ = Typy.inne;
            _cena = 0;
            _dataProdukcji = DateTime.MinValue;
            _dataProdukcji = DateTime.MinValue;
            _kraj = Kraje.inny;
            
        }
        public Towar(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, Kraje kraj) : this()
        {
            _kraj = kraj;
            _nazwa = nazwa;
            _typ = typ;
            _cena = cena;
            DateTime.TryParseExact(dataProdukcji, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out _dataProdukcji);
            DateTime.TryParseExact(dataPrzydatnosci, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MM-yy", "dd.MM.yyyy" }, null, DateTimeStyles.None, out _dataPrzydatnosci);
        }

        public override string ToString()
        {
            return $"{_nazwa}, {_typ} ({_cena:C}, data produkcji: {_dataProdukcji.ToShortDateString()}, data przydatności: {_dataPrzydatnosci.ToShortDateString()})";
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
            return (Towar)MemberwiseClone();
        }

    }
}
