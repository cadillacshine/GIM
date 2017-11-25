using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace GIM {
    class StatusRepository: ICRUD {

        SqlCommand sqlcmd = new SqlCommand();

        public StatusRepository() {
            
        }

        public int getID(string name) {
            sqlcmd = new SqlCommand("SELECT StatusID FROM Status WHERE Name = '" + name + "' ", Misc.getConn());
            Misc.connOpen();
            return (int)sqlcmd.ExecuteScalar();
        }

        public void add(object T) {
            Status status = (Status)T;
            sqlcmd = new SqlCommand("INSERT INTO Status (Name, ShortName, Description, Active) VALUES (@Name, @ShortName, @Description, @Active)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", status.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", status.shortName);
            sqlcmd.Parameters.AddWithValue("@Description", status.description);
            sqlcmd.Parameters.AddWithValue("@Active", status.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public object delete(int id) {
            sqlcmd = new SqlCommand("DELETE FROM Status WHERE StatusID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }

        public DataTable loadData() {
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT Name, ShortName, Description, Active FROM Status ORDER BY Name", Misc.getConn());
            DataTable dTable = new DataTable("Status");
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public DataTable loadActiveData() {
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT Name, ShortName, Description, Active FROM Status WHERE Active = 'True' ORDER BY Name", Misc.getConn());
            DataTable dTable = new DataTable("Status");
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public object find(int id) {
            Status status = new Status();
            sqlcmd = new SqlCommand("SELECT StatusID, Name, ShortName, Description, Active FROM Status WHERE StatusID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            while(dReader.Read()) {
                status.ID = dReader.GetInt32(0);
                status.name = dReader.GetString(1);
                status.shortName = dReader.GetString(2);
                status.description = dReader.GetString(3);
                status.active = dReader.GetBoolean(4);
            }
            dReader.Close();
            return status;
        }

        public object[] findAll() {
            Status status = new Status();
            List<Status> statuses = new List<Status>();
            sqlcmd = new SqlCommand("SELECT StatusID, Name, ShortName, Description, Active FROM Status", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();         
            while (dReader.Read()) {
                status.ID = dReader.GetInt32(0);
                status.name = dReader.GetString(1);
                status.shortName = dReader.GetString(2);
                status.description = dReader.GetString(3);
                status.active = dReader.GetBoolean(4);
                statuses.Add(status);
            }
            dReader.Close();
            return statuses.ToArray();
        }

        public object update(int id, Object T) {
            Status status = (Status)T; 
            sqlcmd = new SqlCommand("UPDATE Status SET Name = @Name, ShortName = @ShortName, Description = @Description, Active = @Active WHERE StatusID = '" + id + "' ", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", status.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", status.shortName);
            sqlcmd.Parameters.AddWithValue("@Description", status.description);
            sqlcmd.Parameters.AddWithValue("@Active", status.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }
    }
}
