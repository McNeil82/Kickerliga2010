using Kickerliga.DAO;
using System;
using System.Collections.Generic;

namespace Kickerliga.DMN
{
    public class Paarung
    {
        private bool ergebnisLoaded = false;
        private Ergebnis ergebnis;

        public int ID
        {
            get;
            private set;
        }

        public string HeimSpieler1
        {
            get;
            set;
        }

        public string HeimSpieler2
        {
            get;
            set;
        }

        public string AuswaertsSpieler1
        {
            get;
            set;
        }

        public string AuswaertsSpieler2
        {
            get;
            set;
        }

        public int HeimSpielerID1
        {
            get;
            set;
        }

        public int HeimSpielerID2
        {
            get;
            set;
        }

        public int AuswaertsSpielerID1
        {
            get;
            set;
        }

        public int AuswaertsSpielerID2
        {
            get;
            set;
        }

        public int ErgebnisID
        {
            get;
            private set;
        }

        public Ergebnis Ergebnis
        {
            set
            {
                ergebnis = value;
            }
            get
            {
                if (!ergebnisLoaded)
                {
                    ergebnis = ErgebnisseDao.ladeErgebnis(this.ErgebnisID);
                    ergebnisLoaded = true;
                }
                return ergebnis;
            }
        }

        public Paarung()
        {
        }

        public Paarung(int ID, int ErgebnisID)
        {
            this.ID = ID;
            this.ErgebnisID = ErgebnisID;
        }

        public static List<Paarung> ladeAllePaarungen()
        {
            return PaarungenDao.ladeAllePaarungen();
        }

        public static bool existsPaarung(int heim1, int heim2, int auswaerts1, int auswaerts2, int saisonId)
        {
            return PaarungenDao.ueberpruefeObPaarungVorhanden(heim1, heim2, auswaerts1, auswaerts2, saisonId);
        }

        public static string speichereKombination(int heim1, int heim2, int auswaerts1, int auswaerts2, int spieltagId)
        {
            return PaarungenDao.speicherePaarung(heim1, heim2, auswaerts1, auswaerts2, spieltagId);
        }

        public static string loeschePaarung(List<int> IDs)
        {
            return PaarungenDao.loeschePaarung(IDs);
        }
    }
}
