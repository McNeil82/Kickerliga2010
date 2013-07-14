using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class ErgebnisseDao
    {
        public static Ergebnis ladeErgebnis(int ID)
        {
            Ergebnis ergebnis = null;
            DbConnection dbCon = new DbConnection(StoredProcedures.ladeErgebnis, false);
            dbCon.cmd.Parameters.AddWithValue(TabelleErgebnisse.Attribute_ID, ID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                ergebnis = new Ergebnis(Convert.ToInt32(dr[TabelleErgebnisse.Attribute_ID]));
                ergebnis.Heimtore = Convert.ToInt32(dr[TabelleErgebnisse.Attribute_Heimtore]);
                ergebnis.Auswaertstore = Convert.ToInt32(dr[TabelleErgebnisse.Attribute_Auswaertstore]);
            }
            dr.Close();

            dbCon.close();

            return ergebnis;
        }
    }
}
