using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GIM {
    class StatusRepository: ICRUD {

        Status status;
        SqlCommand sqlcmd = new SqlCommand();

        public StatusRepository(Status status) {
            this.status = status;
        }

        public void add(object T) {
            Status status = (Status)T;
            sqlcmd = new SqlCommand("INSERT INTO Status (Name, ShortName, Description, Active) VALUES (@Name, @ShortName, @Description, @Active)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", status.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", status.shortName);
            sqlcmd.Parameters.AddWithValue("@Description", status.description);
            sqlcmd.Parameters.AddWithValue("@Active", status.active);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public object delete(int id) {
            sqlcmd = new SqlCommand("DELETE FROM Status WHERE StatusID = '" + id + "' ", Misc.getConn());
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }

        public object find(int id) {
            sqlcmd = new SqlCommand("SELECT StatusID, Name, ShortName, Description, Active FROM Status WHERE StatusID = '" + id + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while(dReader.Read()) {
                status.statusID = dReader.GetInt32(0);
                status.name = dReader.GetString(1);
                status.shortName = dReader.GetString(2);
                status.description = dReader.GetString(3);
                status.active = dReader.GetBoolean(4);
            }
            dReader.Close();
            return status;
        }

        public object[] findAll() {
            List<Status> statuses = new List<Status>();
            sqlcmd = new SqlCommand("SELECT StatusID, Name, ShortName, Description, Active FROM Status", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                status.statusID = dReader.GetInt32(0);
                status.name = dReader.GetString(1);
                status.shortName = dReader.GetString(2);
                status.description = dReader.GetString(3);
                status.active = dReader.GetBoolean(4);
                statuses.Add(status);
            }
            dReader.Close();
            return statuses.ToArray();
        }

        public object update(int id) {
            sqlcmd = new SqlCommand("UPDATE Status SET Name=@Name, ShortName=@ShortName, Description=@Description, Active=@Active WHERE StatusID = '" + id + "' ", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", status.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", status.shortName);
            sqlcmd.Parameters.AddWithValue("@Description", status.description);
            sqlcmd.Parameters.AddWithValue("@Active", status.active);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);

        }
    }
}
