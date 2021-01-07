using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public class TowarPromocyjny : Towar
    {
        double _obnizkaProcent;
        static int _ostatniKodPromocyjny;
        static TowarPromocyjny()
        {
            _ostatniKodPromocyjny = 100;
        }
        public TowarPromocyjny() : base()
        {

        }
        public TowarPromocyjny(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, double obnizkaProcent) : base(nazwa, typ, cena, dataProdukcji, dataPrzydatnosci)
        {
            --OstatniKod;
            ++_ostatniKodPromocyjny;
            Kod = $"{_ostatniKodPromocyjny}-PP";
            _obnizkaProcent = obnizkaProcent;
        }




        public override string ToString()
        {
            return $"{base.ToString()} {_obnizkaProcent}%";
        }
    }
}
