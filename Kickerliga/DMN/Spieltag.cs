using Kickerliga.DAO;
using System;
using System.Collections.Generic;

namespace Kickerliga.DMN
{
    public class Spieltag
    {
        private bool paarungenLoaded = false;
        private List<Paarung> paarungen;

        public int ID
        {
            get;
            private set;
        }

        public DateTime DatumBis
        {
            get;
            set;
        }

        public DateTime DatumVon
        {
            get;
            set;
        }

        public int Kalenderwoche
        {
            get;
            set;
        }

        public int SpieltagNr
        {
            get;
            set;
        }

        public List<Paarung> Paarungen
        {
            set
            {
                paarungen = value;
            }
            get
            {
                if (!paarungenLoaded)
                {
                    paarungen = PaarungenDao.ladePaarungenVonSpieltag(this.ID);
                    paarungenLoaded = true;
                }
                return paarungen;
            }
        }

        public void setLoaded(bool aktuell)
        {
            this.paarungenLoaded = aktuell;
        }

        public string ComboBoxAnzeige
        {
            get
            {
                return SpieltagNr.ToString() + ". vom " + DatumVon.ToShortDateString().ToString()
                     + " bis zum " + DatumBis.ToShortDateString().ToString() + " (" + Kalenderwoche.ToString() + ")";
            }
        }

        public Spieltag()
        {
        }

        public Spieltag(int ID)
        {
            this.ID = ID;
        }

        public string save()
        {
            return SpieltageDao.speichereSpieltag(this);
        }

        public static string speichere(int spieltag, DateTime von, DateTime bis, int kalenderwoche, int saisonID)
        {
            return SpieltageDao.speichereSpieltag(spieltag, von, bis, kalenderwoche, saisonID);
        }

        public static List<Spieltag> ladeAlleSpieltage(int saisonID)
        {
            return SpieltageDao.ladeAlleSpieltage(saisonID);
        }

        public static string loescheSpieltage(List<int> IDs)
        {
            return SpieltageDao.loescheSpieltage(IDs);
        }
    }
}
