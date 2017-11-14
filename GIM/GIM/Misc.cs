using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIM {
    class Misc {
        public static string loginName { get; set; }
        private static SqlConnection conn { get; set; }


        public static void setConn(string connection) {
            if (connection == "Production")
                conn = new SqlConnection(@"data source=FIVE\FIVE14;initial catalog=dbGIMS;integrated security=True");
            else
                conn = new SqlConnection(@"data source=FIVE\FIVE14;initial catalog=dbGIMS;integrated security=True");
        }

        public static SqlConnection getConn() {
            return conn;
        }

        public static void connOpen() {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public static void connClose() {
            conn.Close();
        }

        //public static void setUser(AppUser usr) {
        //    user = usr;
        //}

        //public static AppUser getUser() {
        //    return user;
        //}

        public static void verifyUsername(string username) {

        }

        public static void logActivity(int memberID, string activity) {
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO ActivityLog(UserAccountID, ActivityTime, Activity) VALUES(@UserAccountID, @ActivityTime, @Activity)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@UserAccountID", memberID);
            sqlcmd.Parameters.AddWithValue("ActivityTime", DateTime.Now);
            sqlcmd.Parameters.AddWithValue("@Activity", activity);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public static DataTable loadDataSource(String query, string tableOrView) {
            SqlDataAdapter dtAdapter = new SqlDataAdapter(query, Misc.getConn());
            DataTable dTable = new DataTable(tableOrView);
            dtAdapter.Fill(dTable);
            return dTable;
        }
    }
}
