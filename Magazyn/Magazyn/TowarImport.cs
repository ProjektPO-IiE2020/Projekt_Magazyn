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
        Kraje _kraj;

        static TowarImport()
        {
            _doKodu = 1000;
        }

        public TowarImport() : base()
        {
        }

        public TowarImport(string nazwa, Typy typ, double cena, string dataProdukcji, string dataPrzydatnosci, Kraje kraj) : base(nazwa, typ, cena, dataProdukcji, dataPrzydatnosci, kraj)
        {
            _kraj = kraj;
            Kod = $"{++_doKodu}/{kraj.ToString().Substring(0, 3).ToUpper()}/IM";
        }


        public override string ToString()
        {
            return $"{base.ToString()}, KOD: {Kod}, pochodzenie: {_kraj}";
        }
    }
}
