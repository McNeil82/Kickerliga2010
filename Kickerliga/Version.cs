using Kickerliga.DB;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Kickerliga
{
    public static class Version
    {
        private const int appVersion = 4;
        private static int currentDbVersion;

        public static bool checkVersion()
        {
            bool correct = true;
            currentDbVersion = getVersion();
            if (currentDbVersion == 2)
            {
                updateToVersion3();
            }
            if (currentDbVersion == 3)
            {
                updateToVersion4();
            }

            if (currentDbVersion == 4) { }

            if (currentDbVersion != appVersion)
            {
                MessageBox.Show("Die Version der Datenbank (" + currentDbVersion + ") ist nicht mit der Programmversion (" + appVersion + ") kompatibel.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                correct = false;
            }

            return correct;
        }

        private static void updateToVersion4()
        {
            string sql = "DROP INDEX DatumBis ON " + TabelleSpieltage.Name + ";";
            string sql2 = "DROP INDEX DatumVon ON " + TabelleSpieltage.Name + ";";
            string sql3 = "DROP PROCEDURE " + StoredProcedures.ueberpruefeObPaarungVorhanden + ";";
            string sql4 = "CREATE PROCEDURE " + StoredProcedures.ueberpruefeObPaarungVorhanden + " AS " +
                          "SELECT COUNT(1) " +
                          "FROM " + TabellePaarungen.Name + ", " + TabelleSpieltage.Name + " " +
                          "WHERE ((" + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID1) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID2) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID1) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID2) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID1 + "]) " +
                                "AND (" + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID1) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID2) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID1) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID2) + " = [@" + TabellePaarungen.Attribute_HeimSpielerID2 + "]) " +
                                "AND (" + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID1) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID2) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID1) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID1 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID2) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID1 + "]) " +
                                "AND (" + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID1) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_HeimSpielerID2) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID1) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID2 + "] " +
                                    "OR " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_AuswaertsSpielerID2) + " = [@" + TabellePaarungen.Attribute_AuswaertsSpielerID2 + "])) " +
                           "AND " + TabellePaarungen.fullQualified(TabellePaarungen.Attribute_SpieltagID) + " = " + TabelleSpieltage.fullQualified(TabelleSpieltage.Attribute_ID) + " " +
                           "AND " + TabelleSpieltage.fullQualified(TabelleSpieltage.Attribute_SaisonID) + " = [@" + TabelleSaisons.Attribute_ID + "];";

            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.ConnectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                cmd.Transaction = con.BeginTransaction();
                cmd.ExecuteNonQuery();

                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();

                cmd.CommandText = sql3;
                cmd.ExecuteNonQuery();

                cmd.CommandText = sql4;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE Version SET Version = 4";
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();

                currentDbVersion = 4;
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                MessageBox.Show("Fehler beim Versionsupgrade von " + currentDbVersion + " auf 4:\n" + e.Message, "Fehler",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        private static void updateToVersion3()
        {
            string sql = "CREATE PROCEDURE " + StoredProcedures.aendereSpieler + " AS "
                       + "UPDATE " + TabelleSpieler.Name + " "
                       + "SET Nachname = [@" + TabelleSpieler.Attribute_Nachname + "], Vorname = [@" + TabelleSpieler.Attribute_Vorname + "], Kuerzel = [@" + TabelleSpieler.Attribute_Kuerzel + "] "
                       + "WHERE ID = [@" + TabelleSpieler.Attribute_ID + "];";

            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.ConnectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                cmd.Transaction = con.BeginTransaction();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE Version SET Version = 3";
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();

                currentDbVersion = 3;
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                MessageBox.Show("Fehler beim Versionsupgrade von " + currentDbVersion + " auf 3:\n" + e.Message, "Fehler",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        private static int getVersion()
        {
            int version = 0;
            DbConnection dbCon = new DbConnection(StoredProcedures.version, false);

            try
            {
                OleDbDataReader dr = dbCon.cmd.ExecuteReader();
                if (dr.Read())
                {
                    version = Convert.ToInt32(dr[TabelleVersion.Version]);
                }
                dr.Close();
            }
            catch (Exception)
            {
            }

            dbCon.close();

            return version;
        }

        private static void createVersionTable()
        {
            string sql = "CREATE TABLE Version (Version INT NOT NULL)";

            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.ConnectionString);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                cmd.Transaction = con.BeginTransaction();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO Version VALUES (1)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE PROCEDURE getVersion AS SELECT Version FROM Version";
                cmd.ExecuteNonQuery();

                cmd.Transaction.Commit();
            }
            catch (Exception e)
            {
                cmd.Transaction.Rollback();
                MessageBox.Show("Fehler beim Versionsupgrade von 0 auf 1:\n" + e.Message, "Fehler",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
    }
}
