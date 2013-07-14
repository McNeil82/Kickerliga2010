using System;
using Kickerliga.DAO;

namespace Kickerliga.DMN
{
    public class Ergebnis
    {
        public int ID
        {
            get;
            private set;
        }

        public int Heimtore
        {
            get;
            set;
        }

        public int Auswaertstore
        {
            get;
            set;
        }

        public Ergebnis()
        {
        }

        public Ergebnis(int ID)
        {
            this.ID = ID;
        }
    }
}
