using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kickerliga.DB
{
    class StoredProcedures
    {
        public const string ladeSpieler = "getSpieler";
        public const string ladeAlleSpieler = "getAlleSpieler";
        public const string ladePaarung = "getPaarung";
        public const string ladeAllePaarungen = "getAllePaarungen";
        public const string ladeAlleSpieltage = "getAlleSpieltage";
        public const string ladeAlleSaisons = "getAlleSaisons";
        public const string ladeAktiveSaison = "getAktiveSaison";
        public const string ladePaarungenVonSpieltag = "getPaarungenVonSpieltag";
        public const string ladeErgebnis = "getErgebnis";

        public const string speichereErgebnis = "insertErgebnis";
        public const string speicherePaarung = "insertPaarung";
        public const string speichereSaison = "insertSaison";
        public const string speichereSpieler = "insertSpieler";
        public const string speichereSpieltag = "insertSpieltag";

        public const string aendereErgebnisID = "updateErgebnisId";
        public const string aendereErgebnis = "updateErgebnis";
        public const string aendereSaison = "updateSaison";
        public const string aendereSpieler = "updateSpieler";
        public const string aendereSpieltag = "updateSpieltag";

        public const string loescheErgebnis = "deleteErgebnis";
        public const string loeschePaarung = "deletePaarung";
        public const string loescheSpieltag = "deleteSpieltag";

        public const string bestimmeTabelle = "getTabelle";
        public const string holeLetzteErgebnisID = "getLastInsertedIdFromErgebnisse";

        public const string ueberpruefeObPaarungVorhanden = "checkPaarungVorhanden";

        public const string inaktiviereSaisons = "inaktiviereSaisons";
        public const string aktiviereSaison = "aktiviereSaison";

        public const string version = "getVersion";
    }
}
