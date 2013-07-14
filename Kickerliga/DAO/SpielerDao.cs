using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class SpielerDao
    {
        public static Spieler ladeSpieler(int ID)
        {
            Spieler spieler = null;
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeSpieler, false);
            dbCon.cmd.Parameters.AddWithValue(TabelleSpieler.Attribute_ID, ID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                spieler = new Spieler(Convert.ToInt32(dr[TabelleSpieler.Attribute_ID]));
                spieler.Vorname = Convert.ToString(dr[TabelleSpieler.Attribute_Vorname]);
                spieler.Nachname = Convert.ToString(dr[TabelleSpieler.Attribute_Nachname]);
                spieler.Kuerzel = Convert.ToString(dr[TabelleSpieler.Attribute_Kuerzel]);
            }
            dr.Close();

            dbCon.close();

            return spieler;
        }

        public static List<Spieler> ladeAlleSpieler()
        {
            List<Spieler> alleSpieler = new List<Spieler>();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeAlleSpieler, false);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                Spieler spieler = new Spieler(Convert.ToInt32(dr[TabelleSpieler.Attribute_ID]));
                spieler.Vorname = Convert.ToString(dr[TabelleSpieler.Attribute_Vorname]);
                spieler.Nachname = Convert.ToString(dr[TabelleSpieler.Attribute_Nachname]);
                spieler.Kuerzel = Convert.ToString(dr[TabelleSpieler.Attribute_Kuerzel]);
                alleSpieler.Add(spieler);
            }
            dr.Close();

            dbCon.close();

            return alleSpieler;
        }

        public static string speichereSpieler(Spieler spieler)
        {
            string message = "";

            DbConnection dbCon = new DbConnection(StoredProcedures.speichereSpieler, true);
            if (spieler.ID > 0)
            {
                dbCon.setStoredProcedure(StoredProcedures.aendereSpieler);
            }

            try
            {
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieler.Attribute_Nachname, spieler.Nachname);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieler.Attribute_Vorname, spieler.Vorname);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieler.Attribute_Kuerzel, spieler.Kuerzel);
                if (spieler.ID > 0)
                {
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieler.Attribute_ID, spieler.ID);
                }
                dbCon.cmd.ExecuteNonQuery();

                dbCon.commitTransaction();
            }
            catch (Exception e)
            {
                dbCon.rollBackTransaction();
                message = e.Message;
            }
            finally
            {
                dbCon.close();
            }

            return message;
        }
    }
}
