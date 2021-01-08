using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Magazyn
{
    class TowaryEksport:Magazyn, ICloneable
    {
        public void ZapiszXML(string nazwaPliku)
        {
            ListaPom = new List<TowarEksport>(KolejkaTowaru);
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarEksport>));
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
            {
                xmls.Serialize(sw, ListaPom);
            }
        }

        public static TowaryEksport OdczytajXML(string nazwaPliku)
        {
            if (!File.Exists(nazwaPliku))
            {
                throw new FileNotFoundException();
            }
            TowaryEksport m = new TowaryEksport();
            XmlSerializer xmls = new XmlSerializer(typeof(List<TowarEksport>));
            using (StreamReader sw = new StreamReader(nazwaPliku))
            {
                m.ListaPom = (List<TowarEksport>)(xmls.Deserialize(sw));
            }
            m.KolejkaTowaru = new Queue<TowarEksport>(m.ListaPom);
            return m;
        }

        public object Clone()
        {
            TowaryEksport nowyMagazyn = new TowaryEksport();
            foreach (TowarEksport t in KolejkaTowaru)
            {
                nowyMagazyn.KolejkaTowaru.Enqueue(t.Clone());
            }
            return nowyMagazyn;
        }
    }
}
