namespace Sql2022DependencyBrowser
{
    public class TableField
    {
        public string Name { get; set; }
        public bool Primary { get; set; }
        public bool IdentitySpecification { get; set; }
        public string DataType { get; set; }
        public int Order { get; set; }
    }
}