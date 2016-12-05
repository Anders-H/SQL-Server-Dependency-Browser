using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Sql2012DependencyBrowser
{
    public class DbObject
    {
        public DbObject(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
        public DbObject(SqlConnection cn, string objectName)
        {
            int id;
            string name;
            string type;
            SqlHelper.GetIdAndTypeFromName(cn, objectName, out id, out name, out type);
            Id = id;
            Name = name;
            Type = type;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public override string ToString() => $"{Name} ({Type})";
    }
    public class SysObject : DbObject
    {
        private SysObject(int id, string type, string name, int schemaId, string schemaName) : base(id, name, type)
        {
            SchemaId = schemaId;
            SchemaName = schemaName;
        }
        public int SchemaId { get; set; }
        public string SchemaName { get; set; }

        public static SysObject GetObject(SqlConnection cn, int id, string type)
        {
            var name = "";
            var sId = 0;
            var sName = "";
            using (var cmd = new SqlCommand("SELECT t.name, s.schema_id, s.name as sname FROM sys.objects AS t INNER JOIN sys.schemas AS s ON t.[schema_id] = s.[schema_id] WHERE t.object_id=@id AND t.type_desc=@t", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@t", type);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    if (!r.IsDBNull(0))
                        name = r.GetString(0);
                    if (!r.IsDBNull(1))
                        sId = r.GetInt32(1);
                    if (!r.IsDBNull(2))
                        sName = r.GetString(2);
                }
                r.Close();
            }
            return new SysObject(id, type, name, sId, sName);
        }
        public override string ToString() => SchemaName == "" ? $"[{Name}]" : $"[{SchemaName}].[{Name}]";
        public List<DbObject> GetDependencies(SqlConnection cn)
        {
            var ret = new List<DbObject>();
            try
            {
                var names = new List<string>();
                using (var cmd = new SqlCommand("sp_depends", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@objname", ToString());
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (r.IsDBNull(0))
                            continue;
                        var n = r.GetString(0);
                        if (string.IsNullOrEmpty(n))
                            continue;
                        if (!names.Contains(n))
                            names.Add(n);
                    }
                    r.Close();
                }
                ret.AddRange(names.Select(n => new DbObject(cn, n)));
            }
            catch
            {
                // ignored
            }
            return ret;
        }
        public string GetSource(SqlConnection cn)
        {
            if (Type == "USER_TABLE")
                return "Source not available for table.";
            var ret = new System.Text.StringBuilder();
            try
            {
                using (var cmd = new SqlCommand("sp_HelpText", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@objname", ToString());
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        if (!r.IsDBNull(0))
                            ret.Append(r.GetString(0));
                    }
                    r.Close();
                }
            }
            catch
            {
                // ignored
            }
            return ret.ToString();
        }
    }
}
