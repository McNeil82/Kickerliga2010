using Kickerliga.DAO;
using System;
using System.Collections.Generic;

namespace Kickerliga.DMN
{
    public class Saison : ICloneable
    {
        private bool spieltageLoaded = false;
        private List<Spieltag> spieltage;

        public int ID
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            set;
        }

        public int AnzahlAufsteiger
        {
            get;
            set;
        }

        public int AnzahlAbsteiger
        {
            get;
            set;
        }

        public bool Aktiv
        {
            get;
            set;
        }

        public int Liga
        {
            get;
            set;
        }

        public List<Spieltag> Spieltage
        {
            set
            {
                spieltage = value;
            }
            get
            {
                if (!spieltageLoaded)
                {
                    spieltage = SpieltageDao.ladeAlleSpieltage(this.ID);
                    spieltageLoaded = true;
                }
                return spieltage;
            }
        }

        public void setLoaded(bool aktuell)
        {
            this.spieltageLoaded = aktuell;
        }

        public string ComboBoxAnzeige
        {
            get
            {
                return Liga.ToString() + ". Liga: " + Name;
            }
        }

        public Saison()
        {
        }

        public Saison(int ID)
        {
            this.ID = ID;
        }

        public static List<Saison> ladeAlleSaisons()
        {
            return SaisonsDao.ladeAlleSaisons();
        }

        public static Saison ladeAktiveSaison()
        {
            return SaisonsDao.ladeAktiveSaison();
        }

        public static string speichere(int anzahlAbsteiger, int anzahlAufsteiger, int liga, string name)
        {
            return SaisonsDao.speichereSaison(anzahlAbsteiger, anzahlAufsteiger, liga, name);
        }

        public string save()
        {
            return SaisonsDao.aktualisiereSaison(this);
        }

        public string aktualisiereSpieltage()
        {
            return SaisonsDao.aktualisiereSpieltage(Spieltage);
        }

        public static void aktiviereSaison(int ID)
        {
            SaisonsDao.aktiviereSaison(ID);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Saison Clone()
        {
            return (Saison)this.MemberwiseClone();
        }

    }
}
