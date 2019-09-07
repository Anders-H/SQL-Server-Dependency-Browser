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
        private IMessageDisplayer Md { get; } = new MessageDisplayer();
        private MainWindowController _c;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _c = new MainWindowController(treeView1);
            lblStatus.Text = @"Not connected.";
            _connectionString = "";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Refresh();
            Connect();
        }

        private void btnConnect_Click(object sender, EventArgs e) =>
            Connect();

        private void Connect()
        {
            using (var x = new LoginDialog())
            {
                if (x.ShowDialog(this, _connectionString) != DialogResult.OK)
                    return;
                _serverName = x.ServerName;
                _databaseName = x.DatabaseName;
                _connectionString = x.ConnectionString;
                var serverDisplayName = (string.IsNullOrEmpty(_serverName)
                    ? "[Unknown server]"
                    : _serverName == "." ? "local server" : _serverName);
                var databaseDisplayName = string.IsNullOrEmpty(_databaseName)
                    ? "[Unknown database]"
                    : _databaseName;
                lblStatus.Text = $@"Connected to server {serverDisplayName}, database {databaseDisplayName}.";
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
                    Md.Void(@"Test successful.", @"Test completed");
                }
                else
                {
                    lblStatus.Text = $@"Could not connect server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : _serverName)}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                    Md.Fail(@"Not expected SQL Server version or insufficient permissions.", @"Test failed");
                }
            }
            else
            {
                lblStatus.Text = $@"Could not connect server {(string.IsNullOrEmpty(_serverName) ? "[Unknown server]" : _serverName)}, database {(string.IsNullOrEmpty(_databaseName) ? "[Unknown database]" : _databaseName)}.";
                Md.Fail(@"Can't connect to database.", @"Test failed");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) =>
            LoadRoot();

        private void LoadRoot()
        {
            treeView1.Nodes.Clear();
            Cursor = Cursors.WaitCursor;
            var nodeCheckConstraint = _c.AddRootFolder("Check Constraints", 0);
            var nodeSfunc = _c.AddRootFolder("Functions - Scalar", 0);
            var nodeSp = _c.AddRootFolder("Stored Procedures", 0);
            var nodeTfunc = _c.AddRootFolder("Functions - Table Valued", 0);
            var nodeTable = _c.AddRootFolder("Tables", 0);
            var nodeTrigger = _c.AddRootFolder("Triggers", 0);
            var nodeView = _c.AddRootFolder("Views", 0);
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
                                    n.ImageIndex = 2;
                                    n.SelectedImageIndex = 2;
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
                                    var obj = new DbObject(dep.Id, n.Text, dep.Type);
                                    node.Tag = obj;
                                    var imageIndex = 1;
                                    switch (obj.Type)
                                    {
                                        case "USER_TABLE":
                                            imageIndex = 2;
                                            break;
                                    }
                                    node.ImageIndex = imageIndex;
                                    node.SelectedImageIndex = imageIndex;
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
                    Md.Fail(ex.Message, @"An error has occured");
                }
            }
            Cursor = Cursors.Default;
        }

        private void btnAbout_Click(object sender, EventArgs e) =>
            Md.Tell(
                $@"SQL Server 2016 Dependency Browser version {Application.ProductVersion} for SQL Server 2016 or later.",
                @"About");

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) =>
            btnProperties.Enabled = e.Node?.Tag is DbObject;

        private void btnProperties_Click(object sender, EventArgs e)
        {
            var n = treeView1.SelectedNode;
            if (!(n?.Tag is DbObject x))
                return;
            using (var d = new PropertiesDialog())
                d.ShowDialog(this, x, _connectionString);
        }
    }
}