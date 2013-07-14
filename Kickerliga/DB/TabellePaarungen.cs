using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kickerliga.DB
{
    class TabellePaarungen
    {
        public const string Name = "Paarungen";
        public const string Attribute_ID = "ID";
        public const string Attribute_HeimSpielerID1 = "HeimSpielerID1";
        public const string Attribute_HeimSpielerID2 = "HeimSpielerID2";
        public const string Attribute_AuswaertsSpielerID1 = "AuswaertsSpielerID1";
        public const string Attribute_AuswaertsSpielerID2 = "AuswaertsSpielerID2";
        public const string Attribute_HeimSpielerKuerzel1 = "Heim1";
        public const string Attribute_HeimSpielerKuerzel2 = "Heim2";
        public const string Attribute_AuswaertsSpielerKuerzel1 = "Auswaerts1";
        public const string Attribute_AuswaertsSpielerKuerzel2 = "Auswaerts2";
        public const string Attribute_ErgebnisID = "ErgebnisID";
        public const string Attribute_SpieltagID = "SpieltagID";

        public static string fullQualified(string attribute)
        {
            return Name + "." + attribute;
        }
    }
}
