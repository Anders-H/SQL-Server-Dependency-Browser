using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sql2016DependencyBrowser
{
    public class TableModel
    {
        public string Name { get; set; }
        public List<TableField> Fields { get; } = new List<TableField>();
        public void Load(SqlConnection cn, string name)
        {
            Fields.Clear();

        }
    }
    public class TableField
    {
        public string Name { get; set; }
        public bool Primary { get; set; }
        public bool IdentitySpecification { get; set; }
        public string DataType { get; set; }
        public int Order { get; set; }
    }
}
