using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sql2016DependencyBrowser
{
    public partial class MainWindow : Form
    {
        private string _connectionString = "";
        private string _serverName = "";
        private string _databaseName = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = @"Not connected.";
            _connectionString = "";
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Refresh();
            Connect();
        }
        private void btnConnect_Click(object sender, EventArgs e) => Connect();
        private void Connect()
        {
            using (var x = new LoginDialog())
            {
                if (x.ShowDialog(this, _connectionString) != DialogResult.OK)
                    return;
                _serverName = x.ServerName;
                _databaseName = x.DatabaseName;
                _connectionString = x.ConnectionString;
                lblStatus.Text = $@"Connected to server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : (_serverName == "." ? "local server" : _serverName))}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                LoadRoot();
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            var cnstrBuild = new SqlConnectionStringBuilder(_connectionString);
            Cursor = Cursors.WaitCursor;
            Refresh();
            var success = SqlHelper.TestConnection(cnstrBuild.ConnectionString);
            Cursor = Cursors.Default;
            if (success)
            {
                if (SqlHelper.CheckVersion(cnstrBuild.ConnectionString))
                {
                    lblStatus.Text = $@"Connected to server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : (_serverName == "." ? "local server" : _serverName))}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                    MessageBox.Show(@"Test successful.", @"Test completed", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    lblStatus.Text = $@"Could not connect server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : _serverName)}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                    MessageBox.Show(@"Not expected SQL Server version or insufficient permissions.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                lblStatus.Text = $@"Could not connect server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : _serverName)}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                MessageBox.Show(@"Can't connect to database.", @"Test failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e) => LoadRoot();
        private void LoadRoot()
        {
            treeView1.Nodes.Clear();
            Cursor = Cursors.WaitCursor;
            var nodeCheckConstraint = treeView1.Nodes.Add("Check Constraints");
            nodeCheckConstraint.ImageIndex = 0;
            nodeCheckConstraint.SelectedImageIndex = 0;
            var nodeSfunc = treeView1.Nodes.Add("Functions - Scalar");
            nodeSfunc.ImageIndex = 0;
            nodeSfunc.SelectedImageIndex = 0;
            var nodeSp = treeView1.Nodes.Add("Stored Procedures");
            nodeSp.ImageIndex = 0;
            nodeSp.SelectedImageIndex = 0;
            var nodeTfunc = treeView1.Nodes.Add("Functions - Table Valued");
            nodeTfunc.ImageIndex = 0;
            nodeTfunc.SelectedImageIndex = 0;
            var nodeTable = treeView1.Nodes.Add("Tables");
            nodeTable.ImageIndex = 0;
            nodeTable.SelectedImageIndex = 0;
            var nodeTrigger = treeView1.Nodes.Add("Triggers");
            nodeTrigger.ImageIndex = 0;
            nodeTrigger.SelectedImageIndex = 0;
            var nodeView = treeView1.Nodes.Add("Views");
            nodeView.ImageIndex = 0;
            nodeView.SelectedImageIndex = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand("SELECT object_id, name, type_desc FROM sys.objects UNION SELECT object_id, name, type_desc FROM sys.indexes ORDER BY name", cn))
                    {
                        var r = cmd.ExecuteReader();
                        while (r.Read())
                        {
                            var name = r.IsDBNull(1) ? "" : r.GetString(1);
                            var type = r.IsDBNull(2) ? "" : r.GetString(2);
                            if (string.IsNullOrEmpty(name) || (string.IsNullOrEmpty(type)))
                                continue;
                            var id = r.GetInt32(0);
                            TreeNode n;
                            switch (type)
                            {
                                case "CHECK_CONSTRAINT":
                                    n = nodeCheckConstraint.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "SQL_SCALAR_FUNCTION":
                                    n = nodeSfunc.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "SQL_TABLE_VALUED_FUNCTION":
                                    n = nodeTfunc.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "SQL_STORED_PROCEDURE":
                                    n = nodeSp.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "SQL_TRIGGER":
                                    n = nodeTrigger.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "USER_TABLE":
                                    n = nodeTable.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                                case "VIEW":
                                    n = nodeView.Nodes.Add(name);
                                    n.Tag = new DbObject(id, name, type);
                                    n.ImageIndex = 1;
                                    n.SelectedImageIndex = 1;
                                    n.Nodes.Add("Dummy");
                                    break;
                            }
                        }
                        r.Close();
                    }
                    cn.Close();
                }
            }
            catch
            {
                // ignored
            }
            Cursor = Cursors.Default;
        }
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count != 1) //Identify dummy
                return;
            if (e.Node.Nodes[0].Tag != null)
                return;
            if (e.Node.Nodes[0].Text == @"Dummy")
                PopulateChildren(e.Node); //Dummy identified
        }
        private void PopulateChildren(TreeNode n)
        {
            //Denna körs bara när vi verkligen hittat en child som är en dummy.
            Cursor = Cursors.WaitCursor;
            n.Nodes.Clear();
            if (n.Tag is DbObject dbObject)
            {
                var dbo = dbObject;
                try
                {
                    using (var cn = new SqlConnection(_connectionString))
                    {
                        cn.Open();
                        bool itemIsSysObjects, itemIsIndex;
                        using (var cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM sys.objects WHERE type_desc=@t), (SELECT COUNT(*) FROM sys.indexes WHERE type_desc=@t)", cn))
                        {
                            cmd.Parameters.AddWithValue("@t", dbo.Type);
                            var r = cmd.ExecuteReader();
                            r.Read();
                            itemIsSysObjects = r.GetInt32(0) > 0;
                            itemIsIndex = r.GetInt32(1) > 0;
                            r.Close();
                        }
                        if (itemIsSysObjects)
                        {
                            var o = SysObject.GetObject(cn, dbo.Id, dbo.Type);
                            if (o.Id > 0 && o.SchemaId > 0)
                            {
                                var deps = o.GetDependencies(cn);
                                foreach (var dep in deps)
                                {
                                    var node = n.Nodes.Add(dep.Name);
                                    node.Tag = new DbObject(dep.Id, n.Text, dep.Type);
                                    node.ImageIndex = 1;
                                    node.SelectedImageIndex = 1;
                                    node.Nodes.Add("Dummy");
                                }
                            }
                        }
                        else if (itemIsIndex)
                        {
                            //Do nothing.
                        }
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(ex.Message, @"An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Cursor = Cursors.Default;
        }
        private void btnAbout_Click(object sender, EventArgs e) => MessageBox.Show($@"SQL Server 2012 Dependency Browser version {Application.ProductVersion} for SQL Server 2012 or later.", @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) => btnProperties.Enabled = e.Node?.Tag is DbObject;
        private void btnProperties_Click(object sender, EventArgs e)
        {
            var n = treeView1.SelectedNode;
            var x = n?.Tag as DbObject;
            if (x == null)
                return;
            switch (x.Type)
            {
                case "USER_TABLE":
                    using (var d = new TablePropertiesDialog())
                        d.ShowDialog(this, x, _connectionString);
                    break;
                default:
                    using (var d = new PropertiesDialog())
                        d.ShowDialog(this, x, _connectionString);
                    break;
            }
        }
    }
}
