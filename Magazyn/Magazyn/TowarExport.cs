using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public class TowarEksport : Towar
    {
        static int _doKodu;
        string _kod;
        Kraje _kraj;

        static TowarEksport()
        {
            _doKodu = 1000;
        }

        public TowarEksport() : base()
        {
        }

        public TowarEksport(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, Kraje kraj) : base(nazwa, typ, cena, dataProdukcji, dataPrzydatnosci, kraj)
        {
            _kraj = kraj;
            --OstatniKod;
            _kod = $"{++_doKodu}/{kraj.ToString().Substring(0, 3).ToUpper()}/EX";
        }


        public override string ToString()
        {
            return $"{base.ToString()}, KOD: {_kod}, destynacja: {_kraj}";
        }
    }
}
