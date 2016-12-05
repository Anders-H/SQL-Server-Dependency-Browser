using System.Data.SqlClient;

namespace Sql2012DependencyBrowser
{
    public class SqlHelper
    {
        public static bool TestConnection(SqlConnection cn)
        {
            bool ret;
            try
            {
                cn.Open();
                ret = cn.State == System.Data.ConnectionState.Open;
                cn.Close();
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public static bool TestConnection(string connectionString)
        {
            bool ret;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    ret = TestConnection(cn);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public static bool CheckVersion(string connectionString)
        {
            var ret = false;
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SELECT @@VERSION", cn))
                    {
                        var s = (string)cmd.ExecuteScalar();
                        if (s.ToLower().StartsWith("microsoft sql server "))
                        {
                            int year;
                            if (int.TryParse(s.Substring(21, 4), out year))
                                ret = year >= 2012;
                        }
                    }
                    cn.Close();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
        public static bool GetIdAndTypeFromName(SqlConnection cn, string objectName, out int id, out string name, out string type)
        {
            id = 0;
            name = objectName;
            type = "";
            try
            {
                if (objectName.IndexOf('.') <= -1)
                    return true;
                var splitname = objectName.Split('.');
                name = splitname[1];
                var schemaId = 0;
                using (var cmd = new SqlCommand("SELECT schema_id FROM sys.schemas WHERE name=@n", cn))
                {
                    cmd.Parameters.AddWithValue("@n", splitname[0]);
                    var r = cmd.ExecuteReader();
                    if (r.Read())
                        schemaId = r.IsDBNull(0) ? 0 : r.GetInt32(0);
                    r.Close();
                }
                if (schemaId <= 0)
                    return true;
                using (var cmd = new SqlCommand("SELECT object_id, type_desc FROM sys.objects WHERE name = @n AND schema_id=@s", cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@s", schemaId);
                    var r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        id = r.IsDBNull(0) ? 0 : r.GetInt32(0);
                        type = r.IsDBNull(1) ? "" : r.GetString(1);
                    }
                    r.Close();
                }
                return true;
            }
            catch
            {
                // ignored
            }
            return false;
        }
    }
}
