using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class PaarungenDao
    {
        private static Paarung buildPaarung(OleDbDataReader dr)
        {
            int ergebnisID = 0;
            Int32.TryParse(dr[TabellePaarungen.Attribute_ErgebnisID].ToString(), out ergebnisID);
            Paarung paarung = new Paarung(Convert.ToInt32(dr[TabellePaarungen.Attribute_ID]), ergebnisID);

            paarung.HeimSpieler1 = Convert.ToString(dr[TabellePaarungen.Attribute_HeimSpielerKuerzel1]);
            paarung.HeimSpieler2 = Convert.ToString(dr[TabellePaarungen.Attribute_HeimSpielerKuerzel2]);
            paarung.AuswaertsSpieler1 = Convert.ToString(dr[TabellePaarungen.Attribute_AuswaertsSpielerKuerzel1]);
            paarung.AuswaertsSpieler2 = Convert.ToString(dr[TabellePaarungen.Attribute_AuswaertsSpielerKuerzel2]);
            paarung.HeimSpielerID1 = Convert.ToInt32(dr[TabellePaarungen.Attribute_HeimSpielerID1]);
            paarung.HeimSpielerID2 = Convert.ToInt32(dr[TabellePaarungen.Attribute_HeimSpielerID2]);
            paarung.AuswaertsSpielerID1 = Convert.ToInt32(dr[TabellePaarungen.Attribute_AuswaertsSpielerID1]);
            paarung.AuswaertsSpielerID2 = Convert.ToInt32(dr[TabellePaarungen.Attribute_AuswaertsSpielerID2]);

            return paarung;
        }

        public static List<Paarung> ladeAllePaarungen()
        {
            List<Paarung> paarungen = new List<Paarung>();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeAllePaarungen, false);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                paarungen.Add(buildPaarung(dr));
            }
            dr.Close();

            dbCon.close();

            return paarungen;
        }

        public static List<Paarung> ladePaarungenVonSpieltag(int ID)
        {
            List<Paarung> paarungen = new List<Paarung>();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladePaarungenVonSpieltag, false);
            dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_ID, ID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                paarungen.Add(buildPaarung(dr));
            }
            dr.Close();

            dbCon.close();

            return paarungen;
        }

        public static Paarung ladePaarung(int ID)
        {
            Paarung paarung = null;
            DbConnection dbCon = new DbConnection(StoredProcedures.ladePaarung, false);
            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ID, ID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                paarung = buildPaarung(dr);
            }
            dr.Close();

            dbCon.close();

            return paarung;
        }

        public static bool ueberpruefeObPaarungVorhanden(int heim1, int heim2, int auswaerts1, int auswaerts2, int saisonId)
        {
            bool found = false;

            DbConnection dbCon = new DbConnection(StoredProcedures.ueberpruefeObPaarungVorhanden, false);
            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID1, heim1);
            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID2, heim2);
            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID1, auswaerts1);
            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID2, auswaerts2);
            dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_ID, saisonId);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                found = dr.GetInt32(0) > 0;
            }
            dr.Close();

            dbCon.close();

            return found;
        }

        public static string speicherePaarung(int heim1, int heim2, int auswaerts1, int auswaerts2, int spieltagId)
        {
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                dbCon.setStoredProcedure(StoredProcedures.speicherePaarung);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID1, heim1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID2, heim2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID1, auswaerts1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID2, auswaerts2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_SpieltagID, spieltagId);
                dbCon.cmd.ExecuteNonQuery();

                dbCon.setStoredProcedure(StoredProcedures.speicherePaarung);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID1, heim1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID2, auswaerts1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID1, heim2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID2, auswaerts2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_SpieltagID, spieltagId);
                dbCon.cmd.ExecuteNonQuery();

                dbCon.setStoredProcedure(StoredProcedures.speicherePaarung);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID1, heim1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_HeimSpielerID2, auswaerts2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID1, heim2);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_AuswaertsSpielerID2, auswaerts1);
                dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_SpieltagID, spieltagId);
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

        public static string loeschePaarung(List<int> IDs)
        {

            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    dbCon.setStoredProcedure(StoredProcedures.loeschePaarung);
                    dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ID, IDs[i]);
                    dbCon.cmd.ExecuteNonQuery();
                }

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