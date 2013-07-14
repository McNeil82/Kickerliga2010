using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class SaisonsDao
    {
        public static List<Saison> ladeAlleSaisons()
        {
            List<Saison> saisons = new List<Saison>();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeAlleSaisons, false);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                Saison saison = new Saison(Convert.ToInt32(dr[TabelleSaisons.Attribute_ID]));
                saison.Aktiv = Convert.ToBoolean(dr[TabelleSaisons.Attribute_Aktiv]);
                saison.AnzahlAbsteiger = Convert.ToInt32(dr[TabelleSaisons.Attribute_AnzahlAbsteiger]);
                saison.AnzahlAufsteiger = Convert.ToInt32(dr[TabelleSaisons.Attribute_AnzahlAufsteiger]);
                saison.Liga = Convert.ToInt32(dr[TabelleSaisons.Attribute_Liga]);
                saison.Name = Convert.ToString(dr[TabelleSaisons.Attribute_Bezeichnung]);

                saisons.Add(saison);
            }
            dr.Close();

            dbCon.close();

            return saisons;
        }

        public static Saison ladeAktiveSaison()
        {
            Saison saison = new Saison();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeAktiveSaison, false);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            if (dr.Read())
            {
                saison = new Saison(Convert.ToInt32(dr[TabelleSaisons.Attribute_ID]));
                saison.Aktiv = Convert.ToBoolean(dr[TabelleSaisons.Attribute_Aktiv]);
                saison.AnzahlAbsteiger = Convert.ToInt32(dr[TabelleSaisons.Attribute_AnzahlAbsteiger]);
                saison.AnzahlAufsteiger = Convert.ToInt32(dr[TabelleSaisons.Attribute_AnzahlAufsteiger]);
                saison.Liga = Convert.ToInt32(dr[TabelleSaisons.Attribute_Liga]);
                saison.Name = Convert.ToString(dr[TabelleSaisons.Attribute_Bezeichnung]);
            }
            dr.Close();

            dbCon.close();

            return saison;
        }

        public static string speichereSaison(int anzahlAbsteiger, int anzahlAufsteiger, int liga, string name)
        {
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                dbCon.setStoredProcedure(StoredProcedures.inaktiviereSaisons);
                dbCon.cmd.ExecuteNonQuery();

                dbCon.setStoredProcedure(StoredProcedures.speichereSaison);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_AnzahlAbsteiger, anzahlAbsteiger);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_AnzahlAufsteiger, anzahlAufsteiger);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_Bezeichnung, name);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_Liga, liga);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_Aktiv, -1);
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

        public static void aktiviereSaison(int ID)
        {
            DbConnection dbCon = new DbConnection("", true);
            string message = "";

            try
            {
                dbCon.setStoredProcedure(StoredProcedures.inaktiviereSaisons);
                dbCon.cmd.ExecuteNonQuery();

                dbCon.setStoredProcedure(StoredProcedures.aktiviereSaison);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_ID, ID);
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
        }

        public static string aktualisiereSaison(Saison saison)
        {
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                dbCon.setStoredProcedure(StoredProcedures.aendereSaison);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_AnzahlAbsteiger, saison.AnzahlAbsteiger);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_AnzahlAufsteiger, saison.AnzahlAufsteiger);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_Bezeichnung, saison.Name);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_Liga, saison.Liga);
                dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_ID, saison.ID);
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

        public static string aktualisiereSpieltage(List<Spieltag> spieltage)
        {
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                foreach (Spieltag spieltag in spieltage)
                {
                    dbCon.setStoredProcedure(StoredProcedures.aendereSpieltag);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_Spieltag, spieltag.SpieltagNr);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_DatumVon, spieltag.DatumVon);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_DatumBis, spieltag.DatumBis);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_Kalenderwoche, spieltag.Kalenderwoche);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_ID, spieltag.ID);
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
