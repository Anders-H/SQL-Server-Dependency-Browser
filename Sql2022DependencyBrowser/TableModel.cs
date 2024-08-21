using System.Collections.Generic;
using System.Data.SqlClient;

namespace Sql2022DependencyBrowser
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
}