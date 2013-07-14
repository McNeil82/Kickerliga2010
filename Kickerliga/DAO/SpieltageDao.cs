using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class SpieltageDao
    {
        private static Spieltag buildSpieltag(OleDbDataReader dr)
        {
            Spieltag spieltag = new Spieltag(Convert.ToInt32(dr[TabelleSpieltage.Attribute_ID]));
            spieltag.DatumBis = Convert.ToDateTime(dr[TabelleSpieltage.Attribute_DatumBis]);
            spieltag.DatumVon = Convert.ToDateTime(dr[TabelleSpieltage.Attribute_DatumVon]);
            spieltag.Kalenderwoche = Convert.ToInt32(dr[TabelleSpieltage.Attribute_Kalenderwoche]);
            spieltag.SpieltagNr = Convert.ToInt32(dr[TabelleSpieltage.Attribute_Spieltag]);

            return spieltag;
        }

        public static List<Spieltag> ladeAlleSpieltage(int saisonID)
        {
            List<Spieltag> spieltage = new List<Spieltag>();
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeAlleSpieltage, false);
            dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_SaisonID, saisonID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                spieltage.Add(buildSpieltag(dr));
            }
            dr.Close();

            dbCon.close();

            return spieltage;
        }

        public static string speichereSpieltag(int spieltag, DateTime von, DateTime bis, int kalenderwoche, int saisonID)
        {
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                dbCon.setStoredProcedure(StoredProcedures.speichereSpieltag);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_Spieltag, spieltag);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_DatumVon, von);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_DatumBis, bis);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_Kalenderwoche, kalenderwoche);
                dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_SaisonID, saisonID);
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

        public static string speichereSpieltag(Spieltag spieltag)
        {
            List<Paarung> paarungen = spieltag.Paarungen;
            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                foreach (Paarung paarung in paarungen)
                {
                    Ergebnis ergebnis = paarung.Ergebnis;
                    if (ergebnis == null)
                    {
                        dbCon.setStoredProcedure(StoredProcedures.aendereErgebnisID);
                        dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ErgebnisID, DBNull.Value);
                        dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ID, paarung.ID);
                        dbCon.cmd.ExecuteNonQuery();

                        dbCon.setStoredProcedure(StoredProcedures.loescheErgebnis);
                        dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_ID, paarung.ErgebnisID);
                        dbCon.cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (paarung.ErgebnisID != 0)
                        {
                            dbCon.setStoredProcedure(StoredProcedures.aendereErgebnis);
                            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_Heimtore, ergebnis.Heimtore);
                            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_Auswaertstore, ergebnis.Auswaertstore);
                            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_ID, paarung.ErgebnisID);
                            dbCon.cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            int ergebnisID = 0;
                            dbCon.setStoredProcedure(StoredProcedures.speichereErgebnis);
                            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_Heimtore, ergebnis.Heimtore);
                            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_Auswaertstore, ergebnis.Auswaertstore);
                            dbCon.cmd.ExecuteNonQuery();

                            dbCon.setStoredProcedure(StoredProcedures.holeLetzteErgebnisID);
                            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                ergebnisID = dr.GetInt32(0);
                            }
                            dr.Close();

                            dbCon.setStoredProcedure(StoredProcedures.aendereErgebnisID);
                            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ErgebnisID, ergebnisID);
                            dbCon.cmd.Parameters.AddWithValue(TabellePaarungen.Attribute_ID, paarung.ID);
                            dbCon.cmd.ExecuteNonQuery();
                        }
                    }
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

        public static string loescheSpieltage(List<int> IDs)
        {

            DbConnection dbCon = new DbConnection("", true);

            string message = "";

            try
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    dbCon.setStoredProcedure(StoredProcedures.loescheSpieltag);
                    dbCon.cmd.Parameters.AddWithValue(TabelleSpieltage.Attribute_ID, IDs[i]);
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
