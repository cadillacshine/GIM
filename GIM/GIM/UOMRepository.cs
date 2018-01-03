using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GIM {
    class UOMRepository: ICRUD {

        SqlCommand sqlcmd = new SqlCommand();

        public int getID(string name) {
            sqlcmd = new SqlCommand("SELECT UOMID FROM UnitOfMeasure WHERE Name = '" + name + "' ", Misc.getConn());
            Misc.connOpen();
            return (int)sqlcmd.ExecuteScalar();
        }

        public void add(object T) {
            UnitOfMeasure uom = (UnitOfMeasure)T;
            sqlcmd = new SqlCommand("INSERT INTO UnitOfMeasure (Name, ShortName, Active) VALUES (@Name, @ShortName, @Active)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", uom.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", uom.shortName);
            sqlcmd.Parameters.AddWithValue("@Active", uom.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public object delete(int id) {
            sqlcmd = new SqlCommand("DELETE FROM UnitOfMeasure WHERE UOMID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }

        public object find(int id) {
            UnitOfMeasure uom = new UnitOfMeasure();
            sqlcmd = new SqlCommand("SELECT UOMID, Name, ShortName, Active FROM UnitOfMeasure WHERE UOMID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            while (dReader.Read()) {
                uom.ID = dReader.GetInt32(0);
                uom.name = dReader.GetString(1);
                uom.shortName = dReader.GetString(2);
                uom.active = dReader.GetBoolean(3);
            }
            dReader.Close();
            return uom;
        }

        public object[] findAll() {
            UnitOfMeasure uom = new UnitOfMeasure();
            List<UnitOfMeasure> statuses = new List<UnitOfMeasure>();
            sqlcmd = new SqlCommand("SELECT UOMID, Name, ShortName, Active FROM UnitOfMeasure", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            while (dReader.Read()) {
                uom.ID = dReader.GetInt32(0);
                uom.name = dReader.GetString(1);
                uom.shortName = dReader.GetString(2);
                uom.active = dReader.GetBoolean(3);
                statuses.Add(uom);
            }
            dReader.Close();
            return statuses.ToArray();
        }

        public DataTable loadData() {
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT Name, ShortName, Active FROM UnitOfMeasure ORDER BY Name", Misc.getConn());
            DataTable dTable = new DataTable("UnitOfMeasure");
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public DataTable loadActiveData() {
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT Name, ShortName, Active FROM UnitOfMeasure WHERE Active = 'True' ORDER BY Name", Misc.getConn());
            DataTable dTable = new DataTable("UnitOfMeasure");
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public object update(int id, object T) {
            UnitOfMeasure uom = (UnitOfMeasure)T;
            sqlcmd = new SqlCommand("UPDATE UnitOfMeasure SET Name = @Name, ShortName = @ShortName, Active = @Active WHERE UOMID = '" + id + "' ", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", uom.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", uom.shortName);
            sqlcmd.Parameters.AddWithValue("@Active", uom.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }
    }
}
