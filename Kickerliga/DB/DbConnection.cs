using System;
using System.Data;
using System.Data.OleDb;

namespace Kickerliga.DB
{
    class DbConnection
    {
        private OleDbConnection con;
        public OleDbCommand cmd
        {
            get;
            private set;
        }

        public DbConnection(string storedProcedure, bool transaction)
        {
            con = new OleDbConnection(Properties.Settings.Default.ConnectionString);
            con.Open();
            cmd = new OleDbCommand(storedProcedure, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (transaction)
            {
                cmd.Transaction = con.BeginTransaction();
            }
        }

        public void setStoredProcedure(string storedProcedure)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = storedProcedure;
        }

        public void commitTransaction()
        {
            cmd.Transaction.Commit();
        }

        public void rollBackTransaction()
        {
            cmd.Transaction.Rollback();
        }

        public void close()
        {
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
        }
    }
}
