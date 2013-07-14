using Kickerliga.DB;
using Kickerliga.DMN;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Kickerliga.DAO
{
    class TabelleDao
    {
        public static List<Tabellenzeile> ladeTabelle(int saisonID)
        {
            List<Tabellenzeile> zeilen = new List<Tabellenzeile>();
            DbConnection dbCon = new DbConnection(StoredProcedures.bestimmeTabelle, false);
            dbCon.cmd.Parameters.AddWithValue(TabelleSaisons.Attribute_ID, saisonID);

            OleDbDataReader dr = dbCon.cmd.ExecuteReader();
            while (dr.Read())
            {
                Tabellenzeile zeile = new Tabellenzeile(Convert.ToInt32(dr[AttributeTabelle.Attribute_SpielerID]),
                                                        Convert.ToString(dr[AttributeTabelle.Attribute_Kuerzel]),
                                                        Convert.ToInt32(dr[AttributeTabelle.Attribute_Tore]),
                                                        Convert.ToInt32(dr[AttributeTabelle.Attribute_Gegentore]),
                                                        Convert.ToInt32(dr[AttributeTabelle.Attribute_Spiele]),
                                                        Convert.ToInt32(dr[AttributeTabelle.Attribute_Punkte]),
                                                        Convert.ToInt32(dr[AttributeTabelle.Attribute_Differenz]));

                zeilen.Add(zeile);
            }
            dr.Close();

            dbCon.close();

            return zeilen;
        }
    }
}
