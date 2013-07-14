using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kickerliga.DB
{
    class TabelleSpieltage
    {
        public const string Name = "Spieltage";
        public const string Attribute_ID = "ID";
        public const string Attribute_Spieltag = "Spieltag";
        public const string Attribute_DatumVon = "DatumVon";
        public const string Attribute_DatumBis = "DatumBis";
        public const string Attribute_Kalenderwoche = "Kalenderwoche";
        public const string Attribute_SaisonID = "SaisonID";

        public static string fullQualified(string attribute)
        {
            return Name + "." + attribute;
        }
    }
}
