using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIM {
    class ItemRepository: ICRUD {
        SqlCommand sqlcmd = new SqlCommand();
        UOMRepository uomRepository = new UOMRepository();
        StatusRepository statusRepository = new StatusRepository();

        public void add(object T) {
            Item item = (Item)T;

            int uomID = uomRepository.getID(item.unitOfMeasure);
            int statusID = statusRepository.getID(item.status);

            sqlcmd = new SqlCommand("INSERT INTO Item (Name, ShortName, Alias, Description, Quantity, UOMID, Price, Extension, StatusID, Active) VALUES (@Name, @ShortName, @Alias, @Description, @Quantity, @UOMID, @StatusID, @Active)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", item.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", item.shortName);
            sqlcmd.Parameters.AddWithValue("@Alias", item.alias);
            sqlcmd.Parameters.AddWithValue("@Description", item.description);
            sqlcmd.Parameters.AddWithValue("@Quantity", item.quantity);
            sqlcmd.Parameters.AddWithValue("@UOMID", uomID);
            sqlcmd.Parameters.AddWithValue("@StatusID", statusID);
            sqlcmd.Parameters.AddWithValue("@Active", item.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public object delete(int id) {
            sqlcmd = new SqlCommand("DELETE FROM Item WHERE ItemID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }

        public object find(int id) {
            Item item = new Item();
            sqlcmd = new SqlCommand("SELECT ItemID, Name, ShortName, Alias, Description, Quantity, UOM, Status, Active FROM vwItem WHERE ItemID = '" + id + "' ", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            while (dReader.Read()) {
                item.ID = dReader.GetInt32(0);
                item.name = dReader.GetString(1);
                item.shortName = dReader.GetString(2);
                item.alias = dReader.GetString(3);
                item.description = dReader.GetString(4);
                item.quantity = dReader.GetDouble(5);
                item.unitOfMeasure = dReader.GetString(6);
                item.status = dReader.GetString(7);
                item.active = dReader.GetBoolean(8);
            }
            dReader.Close();
            return item;
        }

        public object[] findAll() {
            Item item = new Item();
            List<Item> items = new List<Item>();
            sqlcmd = new SqlCommand("SELECT ItemID, Name, ShortName, Alias, Description, Quantity, UOM, Status, Active FROM vwItem", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            while (dReader.Read()) {
                item.ID = dReader.GetInt32(0);
                item.name = dReader.GetString(1);
                item.shortName = dReader.GetString(2);
                item.alias = dReader.GetString(3);
                item.description = dReader.GetString(4);
                item.quantity = dReader.GetDouble(5);
                item.unitOfMeasure = dReader.GetString(6);
                item.status = dReader.GetString(7);
                item.active = dReader.GetBoolean(8);
                items.Add(item);
            }
            dReader.Close();
            return items.ToArray();
        }

        public int getID(string name) {
            sqlcmd = new SqlCommand("SELECT ItemID FROM Item WHERE Name = '" + name + "' ", Misc.getConn());
            Misc.connOpen();
            return (int)sqlcmd.ExecuteScalar();
        }

        public DataTable loadData() {
            SqlDataAdapter dtAdapter = new SqlDataAdapter("SELECT ItemID, Name, ShortName, Alias, Description, Quantity, UOM, Status, Active FROM vwItem ORDER BY Name", Misc.getConn());
            DataTable dTable = new DataTable("vwItem");
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public object update(int id, object T) {
            Item item = (Item)T;

            int uomID = uomRepository.getID(item.unitOfMeasure);
            int statusID = statusRepository.getID(item.status);

            sqlcmd = new SqlCommand("UPDATE Item SET Name = @Name, ShortName = @ShortName, Alias= @Alias, Description = @Description, Quantity = @Quantity, UOMID = @UOMID, StatusID = @StatusID, Active = @Active WHERE ItemID = '" + id + "' ", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@Name", item.name);
            sqlcmd.Parameters.AddWithValue("@ShortName", item.shortName);
            sqlcmd.Parameters.AddWithValue("@Alias", item.alias);
            sqlcmd.Parameters.AddWithValue("@Description", item.description);
            sqlcmd.Parameters.AddWithValue("@Quantity", item.quantity);
            sqlcmd.Parameters.AddWithValue("@UOMID", uomID);
            sqlcmd.Parameters.AddWithValue("@StatusID", statusID);
            sqlcmd.Parameters.AddWithValue("@Active", item.active);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
            return find(id);
        }
    }
}
