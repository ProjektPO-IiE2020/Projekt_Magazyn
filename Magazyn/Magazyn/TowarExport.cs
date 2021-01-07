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
        public string Kod { get => _kod; set => _kod = value; }
        static TowarEksport()
        {
            _doKodu = 100;
        }
        public TowarEksport() : base()
        {
        }
        public TowarEksport(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, Kraje kraj) : base(nazwa, typ, cena, dataProdukcji, dataPrzydatnosci)
        {
            _kraj = kraj;
            _kod = $"{++_doKodu}/{kraj.ToString().Substring(0, 2).ToUpper()}/E";
        }


        public override string ToString()
        {
            return $"{base.ToString()}, destynacja: {_kraj}, KOD: {_kod}";
        }
    }
}
