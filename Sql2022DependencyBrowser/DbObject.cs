using System.Data.SqlClient;

namespace Sql2022DependencyBrowser
{
    public class DbObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public DbObject(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public DbObject(SqlConnection cn, string objectName)
        {
            SqlHelper.GetIdAndTypeFromName(cn, objectName, out var id, out var name, out var type);
            Id = id;
            Name = name;
            Type = type;
        }

        public override string ToString() =>
            $"{Name} ({Type})";
    }
}