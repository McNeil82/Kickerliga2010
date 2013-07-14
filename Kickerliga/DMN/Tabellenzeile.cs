using Kickerliga.DAO;
using System;
using System.Collections.Generic;

namespace Kickerliga.DMN
{
    class Tabellenzeile
    {
        public int SpielerID
        {
            get;
            private set;
        }

        public string Kuerzel
        {
            get;
            private set;
        }

        public int Tore
        {
            get;
            private set;
        }

        public int Gegentore
        {
            get;
            private set;
        }

        public int Spiele
        {
            get;
            private set;
        }

        public int Punkte
        {
            get;
            private set;
        }

        public int Differenz
        {
            get;
            private set;
        }
        public Tabellenzeile(int spielerID, string kuerzel, int tore, int gegentore, int spiele, int punkte, int differenz)
        {
            this.SpielerID = spielerID;
            this.Kuerzel = kuerzel;
            this.Tore = tore;
            this.Gegentore = gegentore;
            this.Spiele = spiele;
            this.Punkte = punkte;
            this.Differenz = differenz;
        }

        public static List<Tabellenzeile> ladeTabelle(int saisonID)
        {
            return TabelleDao.ladeTabelle(saisonID);
        }
    }
}
