using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql2012DependencyBrowser
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
