using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    [Serializable]
    public class TowarImport: Towar
    {
        static int _doKodu;   
        string _kod;
        Kraje _kraj;
        public string Kod { get => _kod; set => _kod = value; }
        static TowarImport()
        {
            _doKodu = 1000;
        }
        public TowarImport() : base()
        {

        }
        public TowarImport(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, Kraje kraj) : base(nazwa, typ, cena, dataProdukcji, dataPrzydatnosci)
        {
            _kraj = kraj;
            _kod = $"{++_doKodu}/{kraj.ToString().Substring(0, 2).ToUpper()}/I";
        }


        public override string ToString()
        {
            return $"{base.ToString()}, pochodzenie: {_kraj}, KOD: {_kod}";
        }
    }
}
