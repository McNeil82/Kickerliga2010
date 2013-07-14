using Kickerliga.DAO;
using System;
using System.Collections.Generic;

namespace Kickerliga.DMN
{
    public class Spieler
    {
        public int ID
        {
            get;
            private set;
        }

        public string Kuerzel
        {
            get;
            set;
        }

        public string Nachname
        {
            get;
            set;
        }

        public string Vorname
        {
            get;
            set;
        }

        public Spieler()
        {
        }

        public Spieler(int ID)
        {
            this.ID = ID;
        }

        public static Spieler ladeSpieler(int ID)
        {
            return SpielerDao.ladeSpieler(ID);
        }

        public static List<Spieler> ladeAlleSpieler()
        {
            return SpielerDao.ladeAlleSpieler();
        }

        public string save()
        {
            return SpielerDao.speichereSpieler(this);
        }
    }
}
